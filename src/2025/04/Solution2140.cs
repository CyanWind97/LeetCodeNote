using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2140
/// title:  解决智力问题
/// problems: https://leetcode.cn/problems/solving-questions-with-brainpower
/// date: 20250401
/// </summary>
public static class Solution2140
{
    public static long MostPoints(int[][] questions) {
        var dp = new long[questions.Length + 1];
        for(int i = questions.Length - 1; i >= 0; i--) {
            var (points, brainpower) = (questions[i][0], questions[i][1]);
            if (i + brainpower + 1 < questions.Length) {
                dp[i] = Math.Max(dp[i + 1], points + dp[i + brainpower + 1]);
            } else {
                dp[i] = Math.Max(dp[i + 1], points);
            }
        }

        return dp[0];
    }
}
