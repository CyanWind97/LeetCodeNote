using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 688
/// title: 骑士在棋盘上的概率
/// problems: https://leetcode.cn/problems/knight-probability-in-chessboard
/// date: 20241207
/// </summary>
public static partial class Solution688
{
    public static double KnightProbability(int n, int k, int row, int column) {
        int[][] dirs = [[-2, -1], [-2, 1], [2, -1], [2, 1], [-1, -2], [-1, 2], [1, -2], [1, 2]];
        
        double[,,] dp = new double[k + 1, n, n];
        for (int step = 0; step <= k; step++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (step == 0) {
                        dp[step, i, j] = 1;
                    } else {
                        foreach (int[] dir in dirs) {
                            int r = i + dir[0], c = j + dir[1];
                            if (r >= 0 && r < n && c >= 0 && c < n) 
                                dp[step, i, j] += dp[step - 1, r, c] / 8;
                            
                        }
                    }
                }
            }
        }
        
        return dp[k, row, column];
    }
}
