using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 130
    /// title: 盈利计划
    /// problems: https://leetcode-cn.com/problems/profitable-schemes/
    /// date: 20210609
    /// </summary>
    public static class Solution130
    {
        // 参考解答 背包问题
        public static int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit) {
            int len = group.Length, MOD = (int)1e9 + 7;
            int[,,] dp = new int[len + 1, n + 1, minProfit + 1];
            dp[0, 0, 0] = 1;
            for (int i = 1; i <= len; i++) {
                int members = group[i - 1], earn = profit[i - 1];
                for (int j = 0; j <= n; j++) {
                    for (int k = 0; k <= minProfit; k++) {
                        if (j < members) {
                            dp[i, j, k] = dp[i - 1, j, k];
                        } else {
                            dp[i, j, k] = (dp[i - 1, j, k] + dp[i - 1, j - members, Math.Max(0, k - earn)]) % MOD;
                        }
                    }
                }
            }
            int sum = 0;
            for (int j = 0; j <= n; j++) {
                sum = (sum + dp[len, j, minProfit]) % MOD;
            }
            return sum;
        }
    }
}