using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2209
/// title: 用地毯覆盖后的最少白色砖块
/// problems: https://leetcode.cn/problems/minimum-white-tiles-after-covering-with-carpets
/// date: 20250221
/// </summary>
public static class Solution2209
{
    public static int MinimumWhiteTiles(string floor, int numCarpets, int carpetLen) {
        int n = floor.Length;
    // dp[i][j] 表示使用j条地毯覆盖前i块砖块时，未被覆盖的白色砖块的最少数量
    var dp = new int[n + 1, numCarpets + 1];
    
    // 初始化第一行
    for (int j = 0; j <= numCarpets; j++) {
        dp[0, j] = 0;
    }
    
    // 计算前缀和，用于快速统计区间内的白色砖块数
    var sum = new int[n + 1];
    for (int i = 0; i < n; i++) {
        sum[i + 1] = sum[i] + (floor[i] - '0');
    }
    
    // 动态规划
    for (int i = 1; i <= n; i++) {
        // 不使用任何地毯的情况
        dp[i, 0] = sum[i];
        
        for (int j = 1; j <= numCarpets; j++) {
            // 选择不在位置i放置地毯
            dp[i, j] = dp[i - 1, j] + (floor[i - 1] - '0');
            
            if (i >= carpetLen) {
                // 选择在位置i放置地毯
                dp[i, j] = Math.Min(dp[i, j], dp[i - carpetLen, j - 1]);
            }
            else {
                // 如果地毯长度大于当前位置，可以直接覆盖前i块
                dp[i, j] = Math.Min(dp[i, j], dp[0, j - 1]);
            }
        }
    }
    
    return dp[n, numCarpets];
    }
}
