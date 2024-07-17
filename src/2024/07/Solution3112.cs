using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3112
/// title: 访问消失节点的最少时间
/// problems: https://leetcode.cn/problems/minimum-time-to-visit-disappearing-nodes
/// date: 20240718
/// </summary>
public static class Solution3112
{
    public static int[] MinimumTime(int n, int[][] edges, int[] disappear) {
        var g = Enumerable.Range(0, n)
                    .Select(_ => new List<(int Node, int Time)>())
                    .ToArray();

        foreach(var edge in edges){
            var (u, v, w) = (edge[0], edge[1], edge[2]);
            g[u].Add((v, w));
            g[v].Add((u, w));
        }

        var visited = new bool[n];
        var result = new int[n];
        Array.Fill(result, -1);
        var queue = new PriorityQueue<(int Node, int Time), int>();
        queue.Enqueue((0, 0), 0);

        while(queue.Count > 0){
            var (node, time) = queue.Dequeue();
            if (visited[node])
                continue;

            visited[node] = true;
            if (time >= disappear[node])
                continue;
            
            result[node] = time;

            foreach(var (v, w) in g[node].Where(x => !visited[x.Node])){
                var nextTime = time + w;
                queue.Enqueue((v, nextTime), nextTime);
            }
        }

        return result;
    }
}
