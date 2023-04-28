using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2423
    /// title: 删除字符使频率相同
    /// problems: https://leetcode.cn/problems/remove-letter-to-equalize-frequency/
    /// date: 20230429
    /// </summary>
    public static class Solution2423
    {
        public static bool EqualFrequency(string word) {
            var freqs = word.GroupBy(c => c)
                            .Select(g => g.Count())
                            .OrderBy(c => c)
                            .ToArray();

            return freqs.Length == 1
                || freqs[0] == 1 && freqs[1..].Distinct().Count() == 1
                || freqs[^1] == freqs[^2] + 1 && freqs[..^1].Distinct().Count() == 1;
        }
    }
}