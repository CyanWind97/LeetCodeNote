using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2506
/// title: 统计相似字符串对的数目
/// problems: https://leetcode.cn/problems/count-pairs-of-similar-strings
/// date: 20250222
/// </summary>
public static class Solution2506
{
    public static int SimilarPairs(string[] words) {
        var n = words.Length;
        var map = new Dictionary<string, int>();
        var count = 0;
        foreach (var word in words) {
            var key = new string(word.Distinct().OrderBy(c => c).ToArray());
            if (!map.TryGetValue(key, out int value)) {
                map[key] = 0;
            }

            count += map[key];
            map[key]++;
        }

        return count;
    }
}
