using System;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1374
    /// title:  生成每种字符都是奇数个的字符串
    /// problems: https://leetcode.cn/problems/generate-a-string-with-characters-that-have-odd-counts/
    /// date: 20220801
    /// </summary>
    public static class Solution1374
    {
        public static string GenerateTheString(int n) {
            return n % 2 == 1
                ? new string('a', n)
                : new string('a', n - 1) + 'b';
        }
    }
}