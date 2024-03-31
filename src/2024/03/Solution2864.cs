using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2864
/// title: 最大二进制奇数
/// problems: https://leetcode.cn/problems/maximum-odd-binary-number/description/?envType=daily-question&envId=2024-03-13
/// date: 20240313
/// </summary>
public static class Solution2864
{
    public static string MaximumOddBinaryNumber(string s) {
        int length = s.Length;
        var count = s.Count(c => c == '1');

        var chars = Enumerable.Repeat('1', count - 1)
                .Concat(Enumerable.Repeat('0', length - count))
                .Append('1')
                .ToArray();

        return new string(chars);
    }
}
