using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1388
    /// title: 3n 块披萨
    /// problems: https://leetcode.cn/problems/pizza-with-3n-slices/
    /// date: 20230818
    /// </summary>
    public static class Solution1388
    {
        // 参考解答
        public static int MaxSizeSlices(int[] slices) {
            int length = slices.Length;
            int n = length / 3;
            
            int Calc(int start) {
                var dp = new int[length, n + 1];

                dp[start, 1] = slices[start];
                dp[start + 1, 1] = Math.Max(slices[start], slices[start + 1]);
                
                for(int i = start + 2; i < start + length - 1; i++){
                    for(int j = 1; j <= n; j++){
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 2, j - 1] + slices[i]);
                    }
                }

                return dp[length - 2 + start, n];
            }

            return Math.Max(Calc(0), Calc(1));
        }
    }
}