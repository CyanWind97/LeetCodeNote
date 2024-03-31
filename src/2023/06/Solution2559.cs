using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2559
    /// title: 统计范围内的元音字符串数
    /// problems: https://leetcode.cn/problems/count-vowel-strings-in-ranges/
    /// date: 20230602
    /// </summary>
    public static class Solution2559
    {
        public static int[] VowelStrings(string[] words, int[][] queries) {
            var vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u'};
            int length = words.Length;
            var count = new int[length + 1];
            for(int i = 0; i < length; i++){
                count[i + 1] = count[i];
                if (vowels.Contains(words[i][0]) && vowels.Contains(words[i][^1]))
                    count[i + 1]++;
            }

            var results = Enumerable.Range(0, queries.Length)
                            .Select(i => count[queries[i][1] + 1] - count[queries[i][0]])
                            .ToArray();

            return results;
        }
    }
}