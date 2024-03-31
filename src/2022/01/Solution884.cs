using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 884
    /// title: 两句话中的不常见单词
    /// problems: https://leetcode-cn.com/problems/uncommon-words-from-two-sentences/
    /// date: 20220130
    /// </summary>

    public static class Solution884
    {
        public static string[] UncommonFromSentences(string s1, string s2) {
            return s1.Split(" ")
                    .Concat(s2.Split(" "))
                    .GroupBy(x => x)
                    .Where(x => x.Count() == 1)
                    .Select(x => x.Key)
                    .ToArray();
        }
    }
}