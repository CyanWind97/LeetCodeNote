using System.Linq;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 363
    /// title: 矩形区域不超过 K 的最大数值和
    /// problems: https://leetcode-cn.com/problems/max-sum-of-rectangle-no-larger-than-k/
    /// date: 20210422
    /// </summary>
    public static class Solution363
    {
        public static int MaxSumSubmatrix(int[][] matrix, int k) {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[,] sum = new int[m + 1, n + 1];
            for(int i = 1; i <= m; i++){
                for(int j = 1; j <= n; j++){
                    sum[i, j] = matrix[i - 1][j - 1] + sum[i - 1, j] + sum[i, j - 1] - sum[i - 1, j - 1];
                }
            }

            int result = int.MinValue;
            for(int i = 1; i <= m; i++){
                for(int j = 1; j <= n; j++){
                    for(int p = i; p <= m; p++){
                        for(int q = j; q <= n; q++){
                            int cur = sum[p, q] - sum[i - 1, q] - sum[p, j - 1] + sum[i - 1, j - 1];
                            if(cur <= k){
                                result = Math.Max(cur, result);
                            }
                        }
                    }
                }
            }

            return result;
        }

        // 参考解答
        public static int MaxSumSubmatrix_1(int[][] matrix, int k) {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int result = int.MinValue;
            int[] areaSum = new int[m];
            
            for(int l = 0; l < n; l++)
            {
                areaSum = new int[m];
                for(int r = l; r < n; r++)
                {
                    for(int i = 0; i < m; i++)
                    {
                        areaSum[i] += matrix[i][r];
                    }

                    int max = int.MinValue;
                    for(int p = 0; p < m; p++)
                    {
                        int sum = 0;
                        for(int q = p; q < m; q++)
                        {
                            sum += areaSum[q];
                            if(sum > max && sum <= k)
                            {
                                max = sum;
                            }
                            if(max == k)
                            {
                                return max;
                            }
                        }
                    }

                    result = Math.Max(result, max);
                }
            }
            return result;
        }
        
        
    }
}