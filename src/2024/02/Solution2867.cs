using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2867
/// title: 统计树中的合法路径数目
/// problems: https://leetcode.cn/problems/count-valid-paths-in-a-tree/description/?envType=daily-question&envId=2024-02-27
/// date: 20240227
/// </summary>
public static class Solution2867
{
    // 参考解答
    // 埃氏筛 + 深度优先搜索
    public static long CountPaths(int n, int[][] edges) {
        const int N = 100001;
    
        #region 埃氏筛
        var isPrime = Enumerable.Repeat(true, N).ToArray();
        isPrime[1] = false;
        for (int i = 2; i * i < N; i++) {
            if (!isPrime[i]) 
                continue;
                
            for (int j = i * i; j < N; j += i) {
                isPrime[j] = false;
            }
            
        }
        #endregion

        var graph = Enumerable.Range(0, n + 1)
                        .Select(_ => new List<int>())
                        .ToArray();
        
        foreach (var edge in edges) {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var seen = new List<int>();
        long result = 0;
        var count = new long[n + 1];

        void DFS(int node, int parent) {
            seen.Add(node);
            count[node] = 1;
            foreach (var neighbor in graph[node]) {
                if (neighbor == parent || isPrime[neighbor]) 
                    continue;
                
                DFS(neighbor, node);
            }
        }

        for (int i = 1; i <= n; i++){
            if (!isPrime[i])
                continue;
            
            long cur = 0;
            foreach(var neighbor in graph[i]){
                if (isPrime[neighbor])
                    continue;

                if (count[neighbor] == 0) {
                    seen.Clear();
                    DFS(neighbor, 0);
                    seen.ForEach(k => count[k] = seen.Count);
                }

                result += count[neighbor] * cur;
                cur += count[neighbor];
            }

            result += cur;
        }

        return result;
    }
}
