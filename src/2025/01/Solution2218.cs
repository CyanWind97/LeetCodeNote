using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 2218
/// title: 从栈中取出 K 个硬币的最大面值和
/// problems: https://leetcode.cn/problems/maximum-value-of-k-coins-from-piles
/// date: 20250121
/// </summary>
public static class Solution2218
{
    public static int MaxValueOfCoins(IList<IList<int>> piles, int k) {
        int n = piles.Count;
        var dp = new int[n + 1][];
        for (int i = 0; i <= n; i++) {
            dp[i] = new int[k + 1];
        }

        for (int i = 1; i <= n; i++) {
            for (int j = 0; j <= k; j++) {
                dp[i][j] = dp[i - 1][j]; // 不从当前栈取硬币
                int sum = 0;
                // 从当前栈取x个硬币
                for (int x = 0; x < Math.Min(j, piles[i - 1].Count); x++) {
                    sum += piles[i - 1][x];
                    if (j - x - 1 >= 0) {
                        dp[i][j] = Math.Max(dp[i][j], dp[i - 1][j - x - 1] + sum);
                    }
                }
            }
        }

        return dp[n][k];
    }
}
