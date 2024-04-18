using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1883
/// title: 准时抵达会议现场的最小跳过休息次数
/// problems: https://leetcode.cn/problems/minimum-skips-to-arrive-at-meeting-on-time
/// date: 20240419
/// </summary>
public static class Solution1883
{
    // 参考解答
    // dp
    public static int MinSkips(int[] dist, int speed, int hoursBefore) {
        int n = dist.Length;
        var dp = new long[n + 1, n + 1];
        for(int i = 0; i <= n; i++ ){
            for(int j = 0; j <= n; j++){
                dp[i, j] = long.MaxValue / 2;
            }
        }
        dp[0, 0] = 0;

        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= i; ++j) {
                if (j != i) {
                    dp[i, j] = Math.Min(dp[i, j], ((dp[i - 1, j] + dist[i - 1] - 1) / speed + 1) * speed);
                }
                if (j != 0) {
                    dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1] + dist[i - 1]);
                }
            }
        }
        for (int j = 0; j <= n; ++j) {
            if (dp[n, j] <= (long) hoursBefore * speed) 
                return j;
        }

        return -1;
    }
}
