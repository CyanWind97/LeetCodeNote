using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 224
    /// title:  基本计算器
    /// problems: https://leetcode.cn/problems/basic-calculator/
    /// date: 20220514
    /// priority: 0048
    /// time: 00:17:48.33 timeout
    /// </summary>
    public static class CodeTop224
    {
        public static int Calculate(string s) {
            var stack = new Stack<int>();
            int sign = 1;
            int num = 0;
            int result = 0;

            foreach(var c in s){
                if(c == ' ')
                    continue;
                
                if(char.IsDigit(c))
                    num = num * 10 + (c - '0');
                else if(c == '+'){
                    result += sign * num;
                    num = 0;
                    sign = 1;
                }else if(c == '-'){
                    result += sign * num;
                    num = 0;
                    sign = -1;
                }else if(c == '('){
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                }else if(c == ')'){
                    result += sign * num;
                    num = result * stack.Pop();
                    result = stack.Pop();
                    sign = 1;
                }
            }

            result += sign * num;
            
            return result;
        }
    }
}