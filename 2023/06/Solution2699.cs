using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2699
    /// title: 修改图中的边权
    /// problems: https://leetcode.cn/problems/modify-graph-edge-weights/
    /// date: 20230604
    /// </summary>
    public static class Solution2699
    {
        // 参考解答
        // 两次Dijsktra
        public static int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target) {
            int length = edges.Length;
            var graph = Enumerable.Range(0, n).Select(_ => new List<(int V, int Index)>()).ToArray();
            for(int i = 0; i < length; i++){
                graph[edges[i][0]].Add((edges[i][1], i));
                graph[edges[i][1]].Add((edges[i][0], i));
            }

            var dist = new int[n, 2];
            for(int i = 0; i < n; i++){
                 dist[i, 0] = dist[i, 1] = int.MaxValue;
            }

            dist[source, 0] = dist[source, 1] = 0;
            int delta = -1;

            void Dijkstra(int k) {
                var visited = new bool[n];
                var pq = new PriorityQueue<int, int>(); 
                pq.Enqueue(source, 0);
                while(pq.Count > 0){
                    var v = pq.Dequeue();
                    if(v == destination)
                        return;

                    if(visited[v])
                        continue;

                    visited[v] = true;
                    foreach(var e in graph[v]){
                        (int nextV, int i)=  e;
                        if (visited[nextV])
                            continue;

                        int wt = Math.Max(1, edges[i][2]);

                        if (delta >= 0 && edges[i][2] == -1) {
                            int w = delta + dist[nextV, 0]  - dist[v, 1];
                            if(w > wt)
                                edges[i][2] = wt = w;
                        }
                        
                        if (dist[v, k] + wt < dist[nextV, k]){
                            dist[nextV, k] = dist[v, k] + wt;
                            pq.Enqueue(nextV, dist[nextV, k]);
                        }
                    }
                }
            }
            
            Dijkstra(0);
            delta = target - dist[destination, 0];
            if (delta < 0)
                return new int[0][];

            Dijkstra(1);
            if (dist[destination, 1] < target)
                return new int[0][];
            
            foreach(var e in edges.Where(e => e[2] == -1)) {
                e[2] = 1;
            }

            return edges;
        }
    }
}