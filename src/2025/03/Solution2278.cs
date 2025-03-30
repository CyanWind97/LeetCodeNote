using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2278
/// title:  字母在字符串中的百分比
/// problems: https://leetcode.cn/problems/percentage-of-letter-in-string
/// date: 20250331
/// </summary>

public static class Solution2278
{
    public static int PercentageLetter(string s, char letter) {
        return (int)(s.Count(c => c == letter) * 100 / s.Length);
    }
}
