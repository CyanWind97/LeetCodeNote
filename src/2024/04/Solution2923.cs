using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2923
/// title: 找到冠军 I
/// problems: https://leetcode.cn/problems/find-champion-i
/// date: 20240412
/// </summary>
public static class Solution2923
{
    public static int FindChampion(int[][] grid) {
        int n = grid.Length;

        return Enumerable.Range(0, n)
                .FirstOrDefault(i =>  grid[i].Sum() == n - 1);
    }
}
