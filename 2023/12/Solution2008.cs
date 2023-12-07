using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2008
    /// title: 出租车的最大盈利
    /// problems: https://leetcode.cn/problems/maximum-earnings-from-taxi/description/?envType=daily-question&envId=2023-12-08
    /// date: 20231208
    /// </summary>
    public static class Solution2008
    {
        public static long MaxTaxiEarnings(int n, int[][] rides) {
            Array.Sort(rides, (a, b) => a[1] - b[1]);
            long[] dp = new long[n + 1];
            int index = 0;
            for (int i = 1; i <= n; i++) {
                dp[i] = Math.Max(dp[i], dp[i - 1]);
                while (index < rides.Length && rides[index][1] == i) {
                    dp[rides[index][1]] = Math.Max(dp[rides[index][1]], dp[rides[index][0]] + rides[index][1] - rides[index][0] + rides[index][2]);
                    index++;
                }
            }
            
            return dp[n];
        }
    }
}