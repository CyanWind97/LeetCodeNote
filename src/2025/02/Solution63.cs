using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 63
/// title: 不同路径 II
/// problems: https://leetcode.cn/problems/unique-paths-ii/
/// date: 20250208
/// </summary>
public static class Solution63
{
    public static int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int n = obstacleGrid.Length, m = obstacleGrid[0].Length;
        int[] f = new int[m];
        f[0] = obstacleGrid[0][0] == 0 ? 1 : 0;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                if (obstacleGrid[i][j] == 1) {
                    f[j] = 0;
                } else if (j > 0 && obstacleGrid[i][j - 1] == 0) {
                    f[j] += f[j - 1];
                }
            }
        }
        
        return f[m - 1];
    }
}
