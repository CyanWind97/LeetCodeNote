using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3146
/// title: 两个字符串的排列差
/// problems: https://leetcode.cn/problems/permutation-difference-between-two-strings
/// date: 20240824
/// </summary>
public static class Solution3146
{
    public static int FindPermutationDifference(string s, string t) {
        var sIndex = new int[26];
        for (var i = 0; i < s.Length; i++)
            sIndex[s[i] - 'a'] = i;

        var result = 0;
        for (var i = 0; i < t.Length; i++)
            result += Math.Abs(sIndex[t[i] - 'a'] - i);

        return result;
    }
}
