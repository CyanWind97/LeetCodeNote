using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 819
    /// title: 最常见的单词
    /// problems: https://leetcode-cn.com/problems/most-common-word/
    /// date: 20220417
    /// </summary>
    public static class Solution819
    {
        public static string MostCommonWord(string paragraph, string[] banned) {
            var bannedSet = banned.ToHashSet();
            var words = Regex.Split(paragraph, @"\W+");

            return words.Select(word => word.ToLower())
                 .Where(word => !bannedSet.Contains(word))
                 .GroupBy(word => word)
                 .Select(g => (g.Key, g.Count()))
                 .MaxBy(g => g.Item2)
                 .Key;
        }
    }
}