using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 935
/// title:  骑士拨号器
/// problems: https://leetcode.cn/problems/knight-dialer
/// date: 20241210
/// </summary>
public static class Solution935
{
    public static int KnightDialer(int n) {
        var moves = new int[][]
        {
            [4,6],
            [6,8],
            [7,9],
            [4,8],
            [0,3,9],
            [],
            [0,1,7],
            [2,6],
            [1,3],
            [2,4]
        };

        var dp = new int[2, 10];
        for (int i = 0; i < 10; i++) 
            dp[1, i] = 1;

        const int MOD = 1_000_000_007;
        for (int i = 2; i <= n; i++) {
            int x = i & 1;
            for (int j = 0; j < 10; j++) {
                dp[x, j] = 0;
                foreach (int move in moves[j]) {
                    dp[x, j] = (dp[x, j] + dp[x ^ 1, move]) % MOD;
                }
            }
        }

        int k = n & 1;
        return Enumerable.Range(0, 10)
                        .Aggregate(0, (sum, j) => (sum + dp[k, j]) % MOD);
    }
}
