using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3019
/// title: 按键变更的次数
/// problems: https://leetcode.cn/problems/number-of-changing-keys
/// date: 20250107
/// </summary>
public static class Solution3019
{
    public static int CountKeyChanges(string s) {
        return Enumerable.Range(0, s.Length - 1)
                .Count(i => s[i] != s[i + 1] && Math.Abs(s[i] - s[i + 1]) != 32);
    }
}
