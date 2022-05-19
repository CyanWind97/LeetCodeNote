using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 322
    /// title:   零钱兑换
    /// problems: https://leetcode.cn/problems/coin-change/
    /// date: 20220519
    /// priority: 0085
    /// time: 00:05:04.71
    /// </summary>

    public static class CodeTop322
    {
        public static int CoinChange(int[] coins, int amount) {
            var dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;

            Array.Sort(coins);
            int length = coins.Length;

            for(int i = 1; i <= amount; i++){
                for(int j = 0; j < length && coins[j] <= i; j++){
                    dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}