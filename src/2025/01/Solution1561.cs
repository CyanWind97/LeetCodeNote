using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1561
/// title: 你可以获得的最大硬币数目
/// problems: https://leetcode.cn/problems/maximum-number-of-coins-you-can-get
/// date: 20250122
/// </summary>
public static class Solution1561
{
    public static int MaxCoins(int[] piles) {
        Array.Sort(piles, (a, b) => b - a);
        return Enumerable.Range(0, piles.Length / 3)
            .Sum(i => piles[i * 2 + 1]);
    }
}
