using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3067
/// title: 在带权树网络中统计可连接服务器对数目
/// problems: https://leetcode.cn/problems/count-pairs-of-connectable-servers-in-a-weighted-tree-network
/// date: 20240604
/// </summary>
public static class Solution3067
{
    public static int[] CountPairsOfConnectableServers(int[][] edges, int signalSpeed) {
        int n = edges.Length + 1;
        var g = Enumerable.Range(0, n)
                    .Select(_ => new List<(int V, int W)>())
                    .ToArray();

        foreach (var edge in edges) {
            int u = edge[0], v = edge[1], w = edge[2];
            g[u].Add((v, w));
            g[v].Add((u, w));
        }

        var dist = new Dictionary<(int U, int V), List<int>>();
        var result = new int[n];

        List<int> Calc(int u, int v){
            if (dist.TryGetValue((u, v), out var list))
                return list;

            list = [];
            int currW = 0;

            foreach (var (next, w) in g[v]) {
                if (next == u){
                    list.Add(0);
                    currW = w;
                    continue;
                }

                var nextList = Calc(v, next);
                list.AddRange(nextList.Select(x => x));
            }

            for(int i = 0; i < list.Count; i++){
                list[i] += currW;
            }

            dist[(u, v)] = list;
            return list;
        }

        for(int u = 0; u < n; u++){
            if (g[u].Count == 1)
                continue;
            
            var valids = g[u].Select(x => Calc(u, x.V))
                        .Select(l => l.Where(d => d % signalSpeed == 0))
                        .Where(l => l.Any())
                        .Select(l => l.Count())
                        .ToArray();

            for(int i = 0; i < valids.Length; i++){
                for(int j = i + 1; j < valids.Length; j++){
                    result[u] += valids[i] * valids[j];
                }
            }
        }

        return result;
    }
}
