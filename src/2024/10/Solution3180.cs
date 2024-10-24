using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3180
/// title: 执行操作可获得的最大总奖励 I
/// problems: https://leetcode.cn/problems/maximum-total-reward-using-operations-i
/// date: 20241025
/// </summary>
public static class Solution3180
{
    public static int MaxTotalReward(int[] rewardValues) {
        Array.Sort(rewardValues);
        var max = rewardValues[^1];
        var dp = new int[2 * max];
        dp[0] = 1;

        foreach (var reward in rewardValues) {
            for(int k = 2 * reward - 1; k >= reward; k--){
                if (dp[k - reward] == 1)
                    dp[k] = 1;
            }
        }

        int result = 0;
        for(int i = 1; i < 2 * max; i++){
            if (dp[i] == 1)
                result = i;
        }

        return result;
    }
}
