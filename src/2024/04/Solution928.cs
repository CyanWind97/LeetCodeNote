using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 924
/// title: 尽量减少恶意软件的传播 II
/// problems: https://leetcode.cn/problems/minimize-malware-spread
/// date: 20240417
/// </summary>

public static class Solution928
{
    public static int MinMalwareSpread(int[][] graph, int[] initial) {
        int n = graph.Length;
        var initialSet = Enumerable.Repeat(false, n).ToArray();
        foreach(var i in initial){
            initialSet[i] = true;
        }

        var uf = Enumerable.Range(0, n).ToArray();
        int Find(int x) => uf[x] == x ? x : (uf[x] = Find(uf[x]));
        void Union(int x, int y) => uf[Find(x)] = Find(y);

        for(int u = 0; u < n; u++){
            if(initialSet[u])
                continue;

            for(int v = 0; v < n; v++){
                if(initialSet[v] || graph[u][v] == 0)
                    continue;
                
                Union(u, v);
            }
        }

        var infectedBy = Enumerable.Range(0, n)
                        .Select(_ => new HashSet<int>())
                        .ToArray();
        
        foreach(var v in initial){
            foreach(var u in Enumerable.Range(0, n)
                            .Where(u => !initialSet[u] && graph[u][v] == 1)){
                infectedBy[Find(u)].Add(v);
            }
        }

        var ufSize = new int[n];
        for(int u = 0; u < n; u++){
            ufSize[Find(u)]++;
        }

        var count = new int[n];
        foreach(var u in Enumerable.Range(0, n)
                        .Where(u => infectedBy[u].Count == 1)){
            
            int v = infectedBy[u].First();
            count[v] += ufSize[Find(u)];
        }

        var result = initial[0];
        foreach(var v in initial){
            if(count[v] > count[result] 
            || (count[v] == count[result] && v < result))
                result = v;
        }

        return result;
    }

    // 参考解答
    public static int MinMalwareSpread_1(int[][] graph, int[] initial){
        int n = graph.Length;
        int minCount = int.MaxValue;
        int minIndex = -1;
        Array.Sort(initial);
        foreach (int ban in initial)
        {
            var uf = Enumerable.Range(0, n).ToArray();
            int Find(int x) => uf[x] == x ? x : (uf[x] = Find(uf[x]));
            void Union(int x, int y) => uf[Find(x)] = Find(y);

            for (int i = 0; i < graph.Length; ++i)
                for (int j = i + 1; j < graph.Length; ++j)
                    if (graph[i][j] == 1 && i != ban && j != ban)
                        Union(i, j);
            
            var di = Enumerable.Range(0, graph.Length)
                .GroupBy(i => Find(i))
                .ToDictionary(g => g.Key, g => g.Count());

            int infected = initial.Where(i => i != ban)
                .GroupBy(i => Find(i))
                .Select(g => di[g.Key])
                .Sum();

            if (infected < minCount)
            {
                minCount = infected;
                minIndex = ban;
            }
        }

        return minIndex; 
    } 
}
