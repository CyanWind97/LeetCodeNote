using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3239
/// title: 最少翻转次数使二进制矩阵回文 I
/// problems: https://leetcode.cn/problems/minimum-number-of-flips-to-make-binary-grid-palindromic-i
/// date: 20241115
/// </summary>
public static class Solution3239
{
    public static int MinFlips(int[][] grid) {
        (int m, int n) = (grid.Length, grid[0].Length);

        int rowCount = 0;
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n / 2; j++){
                if (grid[i][j] != grid[i][^(j + 1)])
                    rowCount++;
            }
        }

        int colCount = 0;
        for(int j = 0; j < n; j++){
            for(int i = 0; i < m / 2; i++){
                if (grid[i][j] != grid[^(i + 1)][j])
                    colCount++;
            }
        }

        return Math.Min(rowCount, colCount);
    }
}
