using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2496
    /// title: 数组中字符串的最大值
    /// problems: https://leetcode.cn/problems/maximum-value-of-a-string-in-an-array/
    /// date: 20230623
    /// </summary>
    public static class Solution2496
    {
        public static int MaximumValue(string[] strs) {
            return strs.Select(str => int.TryParse(str, out int value) ? value : str.Length)
                    .Max();
        }
    }
}