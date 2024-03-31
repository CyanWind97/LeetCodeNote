using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1976
/// title: 到达目的地的方案数
/// problems: https://leetcode.cn/problems/number-of-ways-to-arrive-at-destination
/// date: 20240305
/// </summary>
public static class Solution1976
{
    public static int CountPaths(int n, int[][] roads) {
        int mode = 1000000007;
        var g = Enumerable.Range(0, n).Select(i => new List<(int Node, int Time)>()).ToArray();

        foreach (var road in roads) {
            int x = road[0], y = road[1], t = road[2];
            g[x].Add((y, t));
            g[y].Add((x, t));
        }

        var dist = Enumerable.Repeat(long.MaxValue, n).ToArray();
        var count = new int[n];

        var queue = new PriorityQueue<(long Dist, int Node), long>();
        queue.Enqueue((0, 0), 0);
        dist[0] = 0;
        count[0] = 1;

        while(queue.Count > 0) {
            var (du, u) = queue.Dequeue();
            if (du > dist[u]) 
                continue;
            
            foreach (var (dv, v) in g[u]) {
                if (du + v < dist[dv]) {
                    dist[dv] = du + v;
                    count[dv] = count[u];
                    queue.Enqueue((dist[dv], dv), dist[dv]);
                } else if (du + v == dist[dv]) {
                    count[dv] = (count[dv] + count[u]) % mode;
                }
            }
        }
        
        return count[n - 1];
    }
}
