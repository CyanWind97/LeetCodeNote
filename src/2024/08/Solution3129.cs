using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3129
/// title: 找出所有稳定的二进制数组 I
/// problems: https://leetcode.cn/problems/find-all-possible-stable-binary-arrays-i
/// date: 20240806
/// </summary>
public static class Solution3129
{
    public static int NumberOfStableArrays(int zero, int one, int limit) {
        const int MOD = 1_000_000_007;
        var dp = new int[zero + 1, one + 1, 2];
        
        foreach(var i in Enumerable.Range(0, Math.Min(zero, limit) + 1)) {
            dp[i, 0, 0] = 1;
        }

        foreach(var j in Enumerable.Range(0, Math.Min(one, limit) + 1)) {
            dp[0, j, 1] = 1;
        }

        for(int i = 1; i <= zero; i++){
            for(int j = 1; j <= one; j++){
                dp[i, j, 0] = dp[i - 1, j, 0] + dp[i - 1, j, 1];
                if (i > limit)
                    dp[i, j, 0] -= dp[i - limit - 1, j, 1];

                dp[i, j, 0] = (dp[i, j, 0] % MOD + MOD) % MOD;

                dp[i, j, 1] = dp[i, j - 1, 0] + dp[i, j - 1, 1];
                if (j > limit)
                    dp[i, j, 1] -= dp[i, j - limit - 1, 0];

                dp[i, j, 1] = (dp[i, j, 1] % MOD + MOD) % MOD;
            }
        }

        return (dp[zero, one, 0] + dp[zero, one, 1]) % MOD;
    }
}
