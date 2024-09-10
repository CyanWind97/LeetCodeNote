using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2555
/// title:  两个线段获得的最多奖品
/// problems: https://leetcode.cn/problems/maximize-win-from-two-segments
/// date: 20240911
/// </summary>
public static class Solution2555
{
    public static int MaximizeWin(int[] prizePositions, int k) {
        int n = prizePositions.Length;
        var dp = new int[n + 1];
        var result = 0;
        for(int left =0, right = 0; right < n; right++){
            while(prizePositions[right] - prizePositions[left] > k){
                left++;
            }

            result = Math.Max(result, right - left + 1 + dp[left]);
            dp[right + 1] = Math.Max(dp[right], right - left + 1);
        }

        return result;
    }
}
