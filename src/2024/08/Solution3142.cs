using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3142
/// title: 判断矩阵是否满足条件
/// problems: https://leetcode.cn/problems/check-if-grid-satisfies-conditions
/// date: 20240829
/// </summary>
public static class Solution3142
{
    public static bool SatisfiesConditions(int[][] grid) {
        return Enumerable.Range(1, grid.Length - 1)
                .All(i => Enumerable.Range(0, grid[0].Length)
                            .All(j => grid[i][j] == grid[0][j]))
            && !Enumerable.Range(1, grid[0].Length - 1)
                .Any(j => grid[0][j] == grid[0][j - 1]);
    }
}
