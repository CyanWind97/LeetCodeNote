using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 64
    /// title:  最小路径和
    /// problems: https://leetcode.cn/problems/minimum-path-sum/
    /// date: 20220514
    /// priority: 0047
    /// time: 00:08:26.72
    /// </summary>
    public static class CodeTop64
    {

        public static int MinPathSum(int[][] grid) {
            int m = grid.Length;
            int n = grid[0].Length;

            var dp = new int[m, n];

            dp[0, 0] = grid[0][0];

            for(int j = 1; j < n; j++){
                dp[0, j] = dp[0, j - 1] + grid[0][j];
            }
            
            for(int i = 1; i < m; i++){    
                
                dp[i, 0] = dp[i - 1, 0] + grid[i][0];

                for(int j = 1; j < n; j++){
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}