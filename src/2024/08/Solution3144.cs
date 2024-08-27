using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3144
/// title: 分割字符频率相等的最少子字符串
/// problems: https://leetcode.cn/problems/minimum-substring-partition-of-equal-character-frequency
/// date: 20240828
/// </summary>
public static class Solution3144
{
    public static int MinimumSubstringsInPartition(string s) {
        int length = s.Length;
        var dp = new int[length + 1];
        var count = new int[26];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        for(int i = 1; i <= length; i++){
            Array.Fill(count, 0);
            int maxCount = 0;
            int available = 0;
            for (int j = i; j >= 1; j--) {
                int index = s[j - 1] - 'a';
                count[index]++;
                if (count[index] == 1)
                    available++;
                
                maxCount = Math.Max(maxCount, count[index]);
                if(maxCount * available == (i - j + 1) && dp[j - 1] != int.MaxValue)
                    dp[i] = Math.Min(dp[i], dp[j - 1] + 1);
            }
        }

        return dp[length];
    }
}
