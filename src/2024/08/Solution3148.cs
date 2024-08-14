using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3148
/// title: 矩阵中的最大得分
/// problems: https://leetcode.cn/problems/maximum-difference-score-in-a-grid
/// date: 20240815
/// </summary>
public static class Solution3148
{
    public static int MaxScore(IList<IList<int>> grid) {
        (int m, int n) = (grid.Count, grid[0].Count);
        var dp = new int[m, n];
        
        int result = int.MinValue;
        dp[0, 0] = grid[0][0];
        for(int i = 1; i < m; i++){
            result = Math.Max(result,  grid[i][0] - dp[i - 1, 0]);
            dp[i, 0] = Math.Min(dp[i - 1, 0], grid[i][0]);
        }

        for(int j = 1; j < n; j++){
            result = Math.Max(result,  grid[0][j] - dp[0, j - 1]);
            dp[0, j] = Math.Min(dp[0, j - 1], grid[0][j]);
        }

        for(int i = 1; i < m; i++){
            for(int j = 1; j < n; j++){
                result = Math.Max(result, grid[i][j] - Math.Min(dp[i - 1, j], dp[i, j - 1]));
                dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), grid[i][j]);
            }
        }

        return result;
    }
}
