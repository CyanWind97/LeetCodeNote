using System;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 899
    /// title:  有序队列
    /// problems: https://leetcode.cn/problems/orderly-queue/
    /// date: 20220803
    /// </summary>

    public static class Solution899
    {
        // 参考解答
        public static string OrderlyQueue(string s, int k) {
            if (k == 1) {
                string smallest = s;
                var sb = new StringBuilder(s);
                int n = s.Length;
                for (int i = 1; i < n; i++) {
                    char c = sb[0];
                    sb.Remove(0, 1);
                    sb.Append(c);
                    if (sb.ToString().CompareTo(smallest) < 0) 
                        smallest = sb.ToString();
                }
                return smallest;
            } else {
                char[] arr = s.ToCharArray();
                Array.Sort(arr);
                return new string(arr);
            }
        }   
    }
}