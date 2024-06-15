using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 521
    /// title: 最长特殊序列 Ⅰ
    /// problems: https://leetcode-cn.com/problems/longest-uncommon-subsequence-i/
    /// date: 20220305
    /// </summary>
    public static partial class Solution521
    {
        public static int FindLUSlength(string a, string b) 
            => a != b ? Math.Max(a.Length, b.Length) : - 1;
    }
}