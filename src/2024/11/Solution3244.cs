using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3244
/// title: 新增道路查询后的最短距离 II
/// problems: https://leetcode.cn/problems/shortest-distance-after-road-addition-queries-ii
/// date: 20241120
/// </summary>
public static class Solution3244
{
    public static int[] ShortestDistanceAfterQueries(int n, int[][] queries) {
        int[] roads = new int[n];
        for (int i = 0; i < n; i++) {
            roads[i] = i + 1;
        }
        int[] result = new int[queries.Length];
        int dist = n - 1;
        for (int i = 0; i < queries.Length; i++) {
            int k = roads[queries[i][0]];
            roads[queries[i][0]] = queries[i][1];
            while (k != -1 && k < queries[i][1]) {
                int t = roads[k];
                roads[k] = -1;
                k = t;
                dist--;
            }
            result[i] = dist;
        }

        return result;
    }
}
