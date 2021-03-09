using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 224
    /// title: 基本计算器
    /// problems: https://leetcode-cn.com/problems/basic-calculator/
    /// date: 20210310
    /// </summary>
    public static class Solution224
    {
        public static int Calculate(string s) {
            long result = 0;
            Stack<char> stack = new Stack<char>();

            void Merge()
            {
                long tmp = 0;
                Stack<char> digits = new Stack<char>();
                while(stack.Count > 0)
                {
                    var c = stack.Pop();
                    if(c == '(')
                        break;
                    
                    if(c == '+'){
                        tmp += long.Parse(digits.ToArray());
                        digits.Clear();
                    }else if(c == '-'){
                        tmp -= long.Parse(digits.ToArray());
                        digits.Clear();
                    }else{
                        digits.Push(c);
                    }
                }

                if(digits.Count > 0){
                    tmp += long.Parse(digits.ToArray());
                    digits.Clear();
                }

                var chars = tmp.ToString().ToCharArray();
                if(stack.Count > 0){
                    var sign = stack.Peek();
                    if(sign == '-' && chars[0] == '-'){
                        chars[0] = '+';
                        stack.Pop();
                    }else if(sign == '+' && chars[0] == '-'){
                        stack.Pop();
                    }
                }
                
                foreach(var c in chars){
                    stack.Push(c);
                }
            }

            void Calc()
            {
                Stack<char> digits = new Stack<char>();
                while(stack.Count > 0)
                {
                    var c = stack.Pop();
                    if(c == '+'){
                        result += long.Parse(digits.ToArray());
                        digits.Clear();
                    }else if(c == '-'){
                        result -= long.Parse(digits.ToArray());
                        digits.Clear();
                    }else{
                        digits.Push(c);
                    }
                }

                if(digits.Count > 0){
                    result += long.Parse(digits.ToArray());
                    digits.Clear();
                }
            }
            
            foreach(var c in s){
                switch(c)
                {
                    case ')' :
                        Merge();
                        break;
                    case ' ' :
                        break;
                    default:
                        stack.Push(c);
                        break;
                }
            }
            
            Calc();

            return (int)result;
        }

        // 参考解答
        public static int Calculate_1(string s) {
            int res = 0, num = 0, sign = 1;
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == ' ')
                    continue;
                else if (char.IsDigit(c))
                    num = num * 10 + (c - '0');
                else if (c == '+')
                {
                    res += sign * num;
                    num = 0;
                    sign = 1;
                }
                else if (c == '-')
                {
                    res += sign * num;
                    num = 0;
                    sign = -1;
                }
                else if (c == '(')
                {
                    st.Push(res);
                    st.Push(sign);
                    res = 0;
                    sign = 1;
                }
                else if (c == ')')
                {
                    res += sign * num;
                    num = res * st.Pop();
                    res = st.Pop();
                    sign = 1;
                }
            }
            res += sign * num;
            return res;
        }
    }
}