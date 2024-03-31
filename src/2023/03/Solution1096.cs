using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1096
    /// title: 花括号展开 II
    /// problems: https://leetcode.cn/problems/brace-expansion-ii/
    /// date: 20230307
    /// </summary>
    public static class Solution1096
    {
        // 参考解答
        // 栈
        public static IList<string> BraceExpansionII(string expression) {
            var op = new Stack<char>();
            var stack = new Stack<SortedSet<string>>();

            void Combination(){
                var r = stack.Pop();
                var l = stack.Pop();
                if(op.Peek() == '+'){
                    l.UnionWith(r);
                }else{
                    var temp = new SortedSet<string>();
                    foreach(var left in l){
                        foreach(var right in r){
                            temp.Add($"{left}{right}");
                        }
                    }

                    l = temp;
                }

                op.Pop();
                stack.Push(l);
            }

            for(int i = 0; i < expression.Length; i++){
                if(expression[i] == ','){
                    while(op.Count > 0 && op.Peek() == '*'){
                        Combination();
                    }

                    op.Push('+');
                }else if(expression[i] == '{'){
                    if(i > 0 && ((expression[i - 1] == '}' || char.IsLetter(expression[i - 1]))))
                        op.Push('*');
                    
                    op.Push('{');
                }else if(expression[i] == '}'){
                    while(op.Count > 0 && op.Peek() != '{'){
                        Combination();
                    }

                    op.Pop();
                }else{
                    if(i > 0 && (expression[i - 1] == '}' || char.IsLetter(expression[i - 1])))
                        op.Push('*');
                    
                    var sb = new StringBuilder();
                    sb.Append(expression[i]);
                    stack.Push(new SortedSet<string>(){sb.ToString()});
                }
            }

            while(op.Count > 0){
                Combination();
            }

            return stack.Last().ToList();
        }
    }
}