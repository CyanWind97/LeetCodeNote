using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1444
    /// title: 切披萨的方案数
    /// problems: https://leetcode.cn/problems/number-of-ways-of-cutting-a-pizza/
    /// date: 20230817
    /// </summary>
    public static class Solution1444
    {
        // 参考解答
        // 动态规划
        public static int Ways(string[] pizza, int k) {
            int mod = 1_000_000_007;
            (int m, int n) = (pizza.Length, pizza[0].Length);

            var apples = new int[m + 1, n + 1];

            var dp = new int[k + 1, m + 1, n + 1];

            // 预处理
            for (int i = m - 1; i >= 0; i--) {
                for (int j = n - 1; j >= 0; j--) {
                    apples[i,j] = apples[i,j + 1] + apples[i + 1,j] - apples[i + 1,j + 1] + (pizza[i][j] == 'A' ? 1 : 0);
                    dp[1,i,j] = apples[i,j] > 0 ? 1 : 0;
                }
            }

            for (int ki = 2; ki <= k; ki++) {
                for (int i = 0; i < m; i++) {
                    for (int j = 0; j < n; j++) {
                        // 水平方向切
                        for (int i2 = i + 1; i2 < m; i2++) {
                            if (apples[i,j] > apples[i2,j]) {
                                dp[ki,i,j] = (dp[ki,i,j] + dp[ki - 1,i2,j]) % mod;
                            }
                        }
                        // 垂直方向切
                        for (int j2 = j + 1; j2 < n; j2++) {
                            if (apples[i,j] > apples[i,j2]) {
                                dp[ki,i,j] = (dp[ki,i,j] + dp[ki - 1,i,j2]) % mod;
                            }
                        }
                    }
                }
            }

            return dp[k,0,0];
        }
    }
}