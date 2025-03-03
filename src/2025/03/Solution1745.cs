using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeeCodeNote;

/// <summary>
/// no: 1745
/// title: 分割回文串  IV
/// problems: https://leetcode.cn/problems/palindrome-partitioning-iv
/// date: 20250304
/// </summary>
public static class Solution1745
{
    public static bool CheckPartitioning(string s) {
        int n = s.Length;
        // dp[i][j] 表示子串 s[i..j] 是否为回文串
        bool[,] dp = new bool[n, n];
        
        // 初始化长度为1的回文串
        for (int i = 0; i < n; i++) {
            dp[i,i] = true;
        }
        
        // 计算所有可能的回文子串
        for (int len = 2; len <= n; len++) {
            for (int i = 0; i + len - 1 < n; i++) {
                int j = i + len - 1;
                if (len == 2) {
                    dp[i,j] = (s[i] == s[j]);
                } else {
                    dp[i,j] = (s[i] == s[j] && dp[i+1,j-1]);
                }
            }
        }
        
        // 尝试所有可能的分割方案
        // 枚举两个分割点
        for (int i = 0; i < n - 2; i++) {
            if (!dp[0,i]) continue;
            for (int j = i + 1; j < n - 1; j++) {
                if (dp[i+1,j] && dp[j+1,n-1]) {
                    return true;
                }
            }
        }
        
        return false;
    }
}
