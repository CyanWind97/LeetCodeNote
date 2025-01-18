using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2266
/// title: 统计打字方案数
/// problems: https://leetcode.cn/problems/count-number-of-texts
/// date: 20250119
/// </summary>
public static class Solution2266
{
    public static int CountTexts(string pressedKeys) {
        const int MOD = 1000000007;
        int n = pressedKeys.Length;
        var dp = new int[n + 1];
        dp[0] = 1;

        for (int i = 1; i <= n; i++) {
            dp[i] = dp[i - 1];
            if (i > 1 && pressedKeys[i - 1] == pressedKeys[i - 2]) {
                dp[i] = (dp[i] + dp[i - 2]) % MOD;
                if (i > 2 && pressedKeys[i - 1] == pressedKeys[i - 3]) {
                    dp[i] = (dp[i] + dp[i - 3]) % MOD;
                    if ((pressedKeys[i - 1] == '7' || pressedKeys[i - 1] == '9') && i > 3 && pressedKeys[i - 1] == pressedKeys[i - 4]) {
                        dp[i] = (dp[i] + dp[i - 4]) % MOD;
                    }
                }
            }
        }

        return dp[n];
    }
}
