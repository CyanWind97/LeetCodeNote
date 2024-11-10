using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1547
/// title: 切棍子的最小成本
/// problems: https://leetcode.cn/problems/minimum-cost-to-cut-a-stick
/// date: 20241111
/// </summary>
public static class Solution1547
{
    public static int MinCost(int n, int[] cuts) {
        int m = cuts.Length;
        Array.Sort(cuts);

        // 扩展 cuts 数组，包含起点 0 和终点 n
        int[] newCuts = new int[m + 2];
        newCuts[0] = 0;
        newCuts[m + 1] = n;
        for (int i = 0; i < m; i++) {
            newCuts[i + 1] = cuts[i];
        }
        
        // 初始化 dp 数组
        int[,] dp = new int[m + 2, m + 2];
        
        // 填充 dp 数组
        for (int len = 2; len <= m + 1; len++) {
            for (int i = 0; i + len <= m + 1; i++) {
                int j = i + len;
                dp[i, j] = int.MaxValue;
                for (int k = i + 1; k < j; k++) {
                    dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k, j] + newCuts[j] - newCuts[i]);
                }
            }
        }
        
        // 返回从起点到终点的最小切割成本
        return dp[0, m + 1];
    }
}
