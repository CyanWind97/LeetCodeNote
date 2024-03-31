using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2696
    /// title: 删除子串后的字符串最小长度
    /// problems: https://leetcode.cn/problems/minimum-string-length-after-removing-substrings/description/?envType=daily-question&envId=2024-01-10
    /// date: 20240110
    /// </summary>

    public static class Solution2696
    {
        public static int MinLength(string s) {
            var stack = new Stack<char>();
            bool NeedPop(char c)
                => stack.Count > 0 
                && ( c == 'B' && stack.Peek() == 'A'
                ||  c == 'D' && stack.Peek() == 'C');

            foreach(var c in s){
                if (NeedPop(c))
                    stack.Pop();
                else
                    stack.Push(c);
            }

            return stack.Count;
        }
    }
}