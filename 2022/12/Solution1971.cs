using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1971
    /// title: 寻找图中是否存在路径
    /// problems: https://leetcode.cn/problems/find-if-path-exists-in-graph/
    /// date: 20221219
    /// </summary>
    public static class Solution1971
    {
        public static bool ValidPath(int n, int[][] edges, int source, int destination) {
            var adj = new IList<int>[n];
            for (int i = 0; i < n; i++) {
                adj[i] = new List<int>();
            }
            foreach (int[] edge in edges) {
                int x = edge[0], y = edge[1];
                adj[x].Add(y);
                adj[y].Add(x);
            }

            var visited = new bool[n];
            var queue = new Queue<int>();
            queue.Enqueue(source);
            visited[source] = true;
            while (queue.Count > 0) {
                int vertex = queue.Dequeue();
                if (vertex == destination) {
                    break;
                }
                foreach (int next in adj[vertex]) {
                    if (!visited[next]) {
                        queue.Enqueue(next);
                        visited[next] = true;
                    }
                }
            }
            
            return visited[destination];
        }
    }
}