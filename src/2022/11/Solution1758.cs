using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1758
    /// title:  生成交替二进制字符串的最少操作数
    /// problems: https://leetcode.cn/problems/minimum-changes-to-make-alternating-binary-string/
    /// date: 20221129
    /// </summary>
    public static class Solution1758
    {
        public static int MinOperations(string s) {
            int count = s.Where((c, i) => c != (char)('0' + i % 2)).Count();

            return  Math.Min(count, s.Length - count);
        }
    }
}