using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2304
    /// title:  网格中的最小路径代价
    /// problems: https://leetcode.cn/problems/minimum-path-cost-in-a-grid/description/?envType=daily-question&envId=2023-11-22
    /// date: 20231122
    /// </summary>
    public static class Solution2304
    {
        public static int MinPathCost(int[][] grid, int[][] moveCost) {
            (int m, int n) = (grid.Length, grid[0].Length);
            var dp = new int[2, n];
            
            for(int i = 0; i < n; i++){
                dp[0, i] = grid[0][i];
            }

            int curr = 0;
            for(int i = 1; i < m; i++){
                int next = 1 - curr;
                for(int j = 0; j < n; j++){
                    dp[next, j] = int.MaxValue;
                    for(int k = 0; k < n; k++){
                        dp[next, j] = Math.Min(dp[next, j], dp[curr, k] + moveCost[grid[i - 1][k]][j] + grid[i][j]);
                    }
                }

                curr = next;
            }

            var result = int.MaxValue;
            for(int i = 0; i < n; i++){
                result = Math.Min(result, dp[curr, i]);
            }

            return result;
        }
    }
}