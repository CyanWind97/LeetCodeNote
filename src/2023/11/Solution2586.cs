using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2586
    /// title: 统计范围内的元音字符串数
    /// problems: https://leetcode.cn/problems/count-the-number-of-vowel-strings-in-range/description/?envType=daily-question&envId=2023-11-07h
    /// date: 20231107
    /// </summary>
    public static class Solution2586
    {
        public static int VowelStrings(string[] words, int left, int right) {
            var chars = new char[]{'a', 'e', 'i', 'o', 'u'};

            return words[left..(right + 1)]
                    .Count(x => chars.Contains(x[0]) && chars.Contains(x[^1]));
        }
    }
}