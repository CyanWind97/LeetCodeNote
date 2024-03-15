using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2684
/// title:  矩阵中移动的最大次数
/// problems: https://leetcode.cn/problems/maximum-number-of-moves-in-a-grid/description/?envType=daily-question&envId=2024-03-16
/// date: 20240316
/// </summary>
public static class Solution2684
{
    public static int MaxMoves(int[][] grid) {
        (int m, int n) = (grid.Length, grid[0].Length);
        var next = new int[m, n];
        var result = 0;
        
        int DFS(int x, int y) {
            if (y == n - 1) 
                return 0;

            if (next[x, y] != 0) 
                return next[x, y];
            
            int result = 0;
            if (x > 0 && grid[x][y] < grid[x - 1][y + 1])
                result = Math.Max(result, DFS(x - 1, y + 1) + 1);

            if (grid[x][y] < grid[x][y + 1])
                result = Math.Max(result, DFS(x, y + 1) + 1);

            if (x < m - 1  && grid[x + 1][y + 1] > grid[x][y]) 
                result = Math.Max(result, DFS(x + 1, y + 1) + 1);
            
            next[x, y] = result;

            return result;
        }

        for (int i = 0; i < m; i++) {
            result = Math.Max(result, DFS(i, 0));
        }

        return result;
    }
}
