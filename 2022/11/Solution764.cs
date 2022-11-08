using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 764
    /// title: 最大加号标志
    /// problems: https://leetcode.cn/problems/largest-plus-sign/
    /// date: 20221109
    /// </summary> 
    public static class Solution764
    {
        public static int OrderOfLargestPlusSign(int n, int[][] mines) {
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++) {
                dp[i] = new int[n];
                Array.Fill(dp[i], n);
            }
            ISet<int> banned = new HashSet<int>();
            foreach (int[] vec in mines) {
                banned.Add(vec[0] * n + vec[1]);
            }
            int ans = 0;
            for (int i = 0; i < n; i++) {
                int count = 0;
                /* left */
                for (int j = 0; j < n; j++) {
                    if (banned.Contains(i * n + j)) {
                        count = 0;
                    } else {
                        count++;
                    }
                    dp[i][j] = Math.Min(dp[i][j], count);
                }
                count = 0;
                /* right */ 
                for (int j = n - 1; j >= 0; j--) {
                    if (banned.Contains(i * n + j)) {
                        count = 0;
                    } else {
                        count++;
                    }
                    dp[i][j] = Math.Min(dp[i][j], count);
                }
            }
            for (int i = 0; i < n; i++) {
                int count = 0;
                /* up */
                for (int j = 0; j < n; j++) {
                    if (banned.Contains(j * n + i)) {
                        count = 0;
                    } else {
                        count++;
                    }
                    dp[j][i] = Math.Min(dp[j][i], count);
                }
                count = 0;
                /* down */
                for (int j = n - 1; j >= 0; j--) {
                    if (banned.Contains(j * n + i)) {
                        count = 0;
                    } else {
                        count++;
                    }
                    dp[j][i] = Math.Min(dp[j][i], count);
                    ans = Math.Max(ans, dp[j][i]);
                }
            }
            return ans;
        }
    }
}