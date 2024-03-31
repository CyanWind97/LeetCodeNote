using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 322
/// title: 零钱兑换
/// problems: https://leetcode.cn/problems/coin-change
/// date: 20240324
/// </summary>
public static class Solution322
{
    public static int CoinChange(int[] coins, int amount) {
        int[] dp = Enumerable.Repeat(amount + 1, amount + 1).ToArray();
    
        dp[0] = 0;
        foreach (int coin in coins) {
            for (int i = coin; i <= amount; i++) {
                dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
            }
        }

        return dp[amount] == amount + 1 ? -1 : dp[amount];
    }
}
