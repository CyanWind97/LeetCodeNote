using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1403
    /// title:  数组中的字符串匹配
    /// problems: https://leetcode.cn/problems/string-matching-in-an-array/
    /// date: 20220806
    /// </summary>
    public static class Solution1408
    {
        public static IList<string> StringMatching(string[] words) {
            var result = new List<string>();
            for (int i = 0; i < words.Length; i++) {
                for (int j = 0; j < words.Length; j++) {
                    if (i != j && words[j].Contains(words[i])) {
                        result.Add(words[i]);
                        break;
                    }
                }
            }

            return result;
        }
    }
}