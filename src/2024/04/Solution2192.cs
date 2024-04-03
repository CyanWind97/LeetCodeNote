using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2192
/// title: 有向无环图中一个节点的所有祖先
/// problems: https://leetcode.cn/problems/all-ancestors-of-a-node-in-a-directed-acyclic-graph
/// date: 20240404
/// </summary>
public static class Solution2192
{
    public static IList<IList<int>> GetAncestors(int n, int[][] edges) {
        var graph = new List<int>[n];
        var degree = new int[n];

        for(int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach(var edge in edges){
            graph[edge[0]].Add(edge[1]);
            degree[edge[1]]++;
        }

        var queue = new Queue<int>();
        for(int i = 0; i < n; i++){
            if(degree[i] == 0)
                queue.Enqueue(i);
        }

        var result = Enumerable.Range(0, n)
                        .Select(_ => new SortedSet<int>())
                        .ToList();
        while(queue.Count > 0){
            var node = queue.Dequeue();
            foreach(var next in graph[node]){
                result[next].Add(node);
                result[next].UnionWith(result[node]);
                if(--degree[next] == 0)
                    queue.Enqueue(next);
            }
        }

        return result.Select(set => set.ToList())
                .ToList<IList<int>>();
    }
}
