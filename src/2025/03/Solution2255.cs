using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2255
/// title:  统计是给定字符串前缀的字符串数目
/// problems: https://leetcode.cn/problems/count-prefixes-of-a-given-string
/// date: 20250324
/// </summary>
public static class Solution2255
{
    public static int CountPrefixes(string[] words, string s) {
        return words.Count(word => s.StartsWith(word));
    }
}
