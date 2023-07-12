using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 931
    /// title:  下降路径最小和
    /// problems: https://leetcode.cn/problems/minimum-falling-path-sum/
    /// date: 20230713
    /// </summary>
    public static class Solution931
    {
        public static int MinFallingPathSum(int[][] matrix) {
            int n = matrix.Length;
            var dp = new int[n, n];
            for(int j = 0; j < n; j++){
                dp[0, j] = matrix[0][j];
            }

            for(int i = 1; i < n; i++){
                for(int j = 0; j < n; j++){
                    int min = dp[i - 1, j];
                    if(j > 0)
                        min = Math.Min(min, dp[i - 1, j - 1]);
                    if(j < n - 1)
                        min = Math.Min(min, dp[i - 1, j + 1]);
                    
                    dp[i, j] = matrix[i][j] + min;
                }
            }

            int result = dp[n - 1, 0];
            for(int i = 1; i < n; i++){
                result = Math.Min(result, dp[n - 1, i]);
            }

            return result;
        }
    }
}