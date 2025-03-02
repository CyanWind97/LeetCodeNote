using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeeCodeNote;

/// <summary>
/// no: 1278
/// title: 分割回文串 III
/// problems: https://leetcode.cn/problems/palindrome-partitioning-iii
/// date: 20250303
/// </summary>
public static class Solution1278
{
    public static int PalindromePartition(string s, int k) {
         int n = s.Length;
    
        // cost[i][j]表示将子串s[i..j]变成回文串所需的最小修改次数
        int[,] cost = new int[n, n];
        for (int len = 2; len <= n; len++) {
            for (int i = 0; i + len - 1 < n; i++) {
                int j = i + len - 1;
                cost[i,j] = cost[i+1,j-1];
                if (s[i] != s[j]) {
                    cost[i,j]++;
                }
            }
        }

        // dp[i][j]表示将前i个字符分成j个回文串所需的最小修改次数
        int[,] dp = new int[n + 1, k + 1];
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j <= k; j++) {
                dp[i,j] = int.MaxValue / 2;
            }
        }
        dp[0,0] = 0;

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= Math.Min(i, k); j++) {
                if (j == 1) {
                    dp[i,j] = cost[0,i-1];
                    continue;
                }
                // 枚举最后一个回文串的起点
                for (int p = j - 1; p < i; p++) {
                    dp[i,j] = Math.Min(dp[i,j], dp[p,j-1] + cost[p,i-1]);
                }
            }
        }

        return dp[n,k];
    }
}
