using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1377
    /// title: T 秒后青蛙的位置
    /// problems: https://leetcode.cn/problems/frog-position-after-t-seconds/
    /// date: 20230524
    /// </summary>
    public static class Solution1377
    {
        // 参考解答
        // DFS
        public static double FrogPosition(int n, int[][] edges, int t, int target) {
            var graph = Enumerable.Range(0, n + 1)
                            .Select(_ => new List<int>())
                            .ToList();
            
            foreach(var edge in edges){
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            var visited = new bool[n + 1];
            visited[1] = true;
            double DFS(int node, int time){
                int nextCount = node == 1 ? graph[node].Count : graph[node].Count - 1;

                if (time == 0 || nextCount == 0)
                    return node == target ? 1.0 : 0.0;

                visited[node] = true;
                var result = 0.0;
                foreach(var next in graph[node]){
                    if(!visited[next])
                        result += DFS(next, time - 1);
                }

                return result / nextCount;
            }

            return DFS(1, t);
        }
    }
}