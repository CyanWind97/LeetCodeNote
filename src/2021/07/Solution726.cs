using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 726
    /// title: 原子的数量
    /// problems: https://leetcode-cn.com/problems/number-of-atoms/
    /// date: 20210705
    /// </summary>
    public static class Solution726
    {
        public static string CountOfAtoms(string formula) {
            int i = 0;
            int n = formula.Length;

            string ParseAtom(){
                StringBuilder sb = new StringBuilder();
                sb.Append(formula[i++]);
                while(i < n && char.IsLower(formula[i])){
                    sb.Append(formula[i++]);
                }

                return sb.ToString();
            }

            int ParseNum(){
                if(i == n || !char.IsNumber(formula[i]))
                    return 1;
                
                int num = 0;
                while(i < n && char.IsNumber(formula[i])){
                    num = num * 10 + formula[i++] - '0';
                }

                return num;
            }

            var stack = new Stack<Dictionary<string,int>>();
            stack.Push(new Dictionary<string, int>());
            while(i < n){
                char ch = formula[i];
                if(ch == '('){
                    i++;
                    stack.Push(new Dictionary<string, int>());
                }else if(ch == ')'){
                    i++;
                    int num = ParseNum();
                    var pop = stack.Pop();
                    var top = stack.Peek();
                    foreach(var pair in pop){
                        string atom = pair.Key;
                        int count = pair.Value * num;
                        if(top.ContainsKey(atom))
                            top[atom] += count;
                        else
                            top.Add(atom, count);
                    }
                }else{
                    string atom = ParseAtom();
                    int num = ParseNum();
                    var top = stack.Peek();
                    if(top.ContainsKey(atom))
                        top[atom] += num;
                    else
                        top.Add(atom, num);
                }
            }

            var dic = stack.Pop();
            var result = new StringBuilder();
            foreach(var pair in  dic.OrderBy(x => x.Key)){
                result.Append(pair.Key);
                if(pair.Value > 1)
                    result.Append(pair.Value);
            }

            return result.ToString();
        }
    }
}