using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1078
    /// title: Bigram 分词
    /// problems: https://leetcode-cn.com/problems/occurrences-after-bigram/
    /// date: 20211226
    /// </summary>
    public static class Solution1078
    {
        public static string[] FindOcurrences(string text, string first, string second) {
            var words = text.Split(" ");
            int length = words.Length;

            return Enumerable.Range(2, words.Length - 2)
                             .Where(index => words[index - 2] == first && words[index - 1] == second)
                             .Select(index => words[index])
                             .ToArray();
        }
    }
}