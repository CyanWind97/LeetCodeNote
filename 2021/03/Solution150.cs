using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 150
    /// title: 逆波兰表达式求值
    /// problems: https://leetcode-cn.com/problems/evaluate-reverse-polish-notation/
    /// date: 20210320
    /// </summary>
    public static class Solution150
    {
        public static int EvalRPN(string[] tokens) {
            Stack<int> stack = new Stack<int>();

            foreach(var s in tokens){
                if(int.TryParse(s, out int num)){
                    stack.Push(int.Parse(s));
                }else{
                    int num1 = stack.Pop();
                    int num2 = stack.Pop();
                    if(s == "+")
                        stack.Push(num2 + num1);
                    else if(s == "-")
                        stack.Push(num2 - num1);
                    else if(s == "*")
                        stack.Push(num2 * num1);
                    else
                        stack.Push(num2 / num1);
                }
            }

            return stack.Pop();
        }
    }
}