using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 227
    /// title: 基本计算器 II
    /// problems: https://leetcode-cn.com/problems/basic-calculator-ii/
    /// date: 20210311
    /// </summary>
    public static class Solution227
    {
        public static int Calculate(string s) {
            Stack<int> st = new Stack<int>();
            char lastOp = '+';
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                    continue;
                else if (char.IsDigit(s[i])){
                    int num = s[i] - '0';
                    while(++i < s.Length && char.IsDigit(s[i])){
                        num = num * 10 + (s[i] - '0');
                    } 
                    i--;

                    if(lastOp == '+') 
                        st.Push(num);
                    else if(lastOp == '-')
                        st.Push(-num);
                    else if(lastOp == '*')
                        st.Push(st.Pop() * num);
                    else
                        st.Push(st.Pop() / num);
                }else
                    lastOp = s[i];
            }
           
            return st.Sum();
        }
    }
}