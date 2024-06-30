using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2065
/// title: 最大化一张图中的路径价值
/// problems: https://leetcode.cn/problems/maximum-path-quality-of-a-graph
/// date: 20240701
/// </summary>
public static class Solution2065
{
    public static int MaximalPathQuality(int[] values, int[][] edges, int maxTime) {
        int result = 0;
        int n = values.Length;
        var g = Enumerable.Range(0, n)
            .Select(_ => new List<(int Node, int Time)>())
            .ToArray();
        
        foreach(var edge in edges){
            g[edge[0]].Add((edge[1], edge[2]));
            g[edge[1]].Add((edge[0], edge[2]));
        }

        var visited = new bool[n];
        visited[0] = true;

        void DFS(int node, int time, int value){
            if (node == 0)
                result = Math.Max(result, value);

            foreach(var (next, nextTime) in g[node]){
                if (time + nextTime > maxTime)
                    continue;

                if (!visited[next]){
                    visited[next] = true;
                    DFS(next, time + nextTime, value + values[next]);
                    visited[next] = false;
                }else{
                    DFS(next, time + nextTime, value);
                }
            }
        }

        DFS(0, 0, values[0]);

        return result;
    }
}
