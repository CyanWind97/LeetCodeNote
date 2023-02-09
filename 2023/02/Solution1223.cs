using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    // <summary>
    /// no: 1223
    /// title: 掷骰子模拟
    /// problems: https://leetcode.cn/problems/dice-roll-simulation/
    /// date: 20230210
    /// </summary>
    public static class Solution1223
    {
        // 参考解答
        // 动态规划
        public static int DieSimulator(int n, int[] rollMax) {
            const int MOD = 1000000007;

            var dp = new int[n + 1, 6];
            var sum = new int[n + 1];
            sum[0] = 1;
            for (int i = 1; i <= n; i++) {
                for (int j = 0; j < 6; j++) {
                    int pos = Math.Max(i - rollMax[j] - 1, 0);
                    int sub = ((sum[pos] - dp[pos, j]) % MOD + MOD) % MOD;
                    dp[i, j] = ((sum[i - 1] - sub) % MOD + MOD) % MOD;
                    if (i <= rollMax[j]) 
                        dp[i, j] = (dp[i, j] + 1) % MOD;
                    
                    sum[i] = (sum[i] + dp[i, j]) % MOD;
                }
            }

            return sum[n];
        }
    }
}