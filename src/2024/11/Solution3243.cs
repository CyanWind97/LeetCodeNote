using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 3243
/// title: 新增道路查询后的最短距离 I
/// problems: https://leetcode.cn/problems/shortest-distance-after-road-addition-queries-i
/// date: 20241119
/// </summary>
public static class Solution3243
{
    public static int[] ShortestDistanceAfterQueries(int n, int[][] queries) {
        var g = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        var dp = new int[n];
        for(int i = 1; i < n; i++) {
            g[i].Add(i - 1);
            dp[i] = i;
        }

        var result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            var (u, v) = (queries[i][0], queries[i][1]);
            g[v].Add(u);
            for(int node = v; node < n; node++) {
                foreach(var prev in g[node]){
                    dp[node] = Math.Min(dp[node], dp[prev] + 1);
                }
            }

            result[i] = dp[n - 1];
        }

        return result;
    }
}
