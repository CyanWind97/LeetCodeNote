using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1047
    /// title: 删除字符串中的所有相邻重复项
    /// problems: https://leetcode-cn.com/problems/remove-all-adjacent-duplicates-in-string/
    /// date: 20210309
    /// </summary>
    public static class Solution1047
    {
        public static string RemoveDuplicates(string S) {
            Stack<char> stack = new Stack<char>();
            foreach(var c in S){
                if(stack.Count > 0 && stack.Peek() == c){
                   stack.Pop();
                   continue;
                }
                stack.Push(c);
            }
            var chars = stack.ToArray();
            Array.Reverse(chars);
            return new string(chars);
        } 

        // 参考解答
        public static string RemoveDuplicates_1(string S) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in S)
            {
                if (sb.Length > 0 && c == sb[sb.Length - 1])
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    sb.Append(c);
                }
            }            
            return sb.ToString();
        }
        
    }
}