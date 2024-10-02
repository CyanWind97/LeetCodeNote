using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1928
/// title: 规定时间内到达终点的最小花费
/// problems: https://leetcode.cn/problems/minimum-cost-to-reach-destination-in-time
/// date: 20241003
/// </summary>
public static class Solution1928
{
    // 参考解答
    public static int MinCost(int maxTime, int[][] edges, int[] passingFees) {
        int n = passingFees.Length;
        int[,] f = new int[maxTime + 1, n];
        for (int i = 0; i <= maxTime; i++) {
            for (int j = 0; j < n; j++) {
                f[i, j] = int.MaxValue;
            }
        }
        f[0, 0] = passingFees[0];
        for (int t = 1; t <= maxTime; t++) {
            foreach (var edge in edges) {
                int i = edge[0], j = edge[1], cost = edge[2];
                if (cost <= t) {
                    if (f[t - cost, j] != int.MaxValue) {
                        f[t, i] = Math.Min(f[t, i], f[t - cost, j] + passingFees[i]);
                    }
                    if (f[t - cost, i] != int.MaxValue) {
                        f[t, j] = Math.Min(f[t, j], f[t - cost, i] + passingFees[j]);
                    }
                }
            }
        }
        
        int ans = int.MaxValue;
        for (int t = 1; t <= maxTime; t++) {
            ans = Math.Min(ans, f[t, n - 1]);
        }
        return ans == int.MaxValue ? -1 : ans;
    }
}
