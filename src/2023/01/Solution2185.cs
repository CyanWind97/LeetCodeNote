using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2185
    /// title: 统计包含给定前缀的字符串
    /// problems: https://leetcode.cn/problems/counting-words-with-a-given-prefix/
    /// date: 20230108
    /// </summary>
    public static class Solution2185
    {
        public static int PrefixCount(string[] words, string pref) {

            return words.Count(word => word.StartsWith(pref));
        }
    }
}