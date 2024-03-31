using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2642
/// title: 设计可以求最短路径的图类
/// problems: https://leetcode.cn/problems/design-graph-with-shortest-path-calculator
/// date: 20240326
/// </summary>
public static class Solution2642
{
    public class Graph {
        private IList<(int Node, int Cost)>[] _graph;

        public Graph(int n, int[][] edges) {
            _graph = Enumerable.Range(0, n)
                        .Select(_ => new List<(int Node, int Cost)>())
                        .ToArray();
            
            foreach(var edge in edges) {
                AddEdge(edge);
            }
        }   
        
        public void AddEdge(int[] edge) {
            (int x, int y, int cost) = (edge[0], edge[1], edge[2]);
            _graph[x].Add((y, cost));
        }
        
        public int ShortestPath(int node1, int node2) {
            var pq = new PriorityQueue<(int Node, int Cost), int>();
            var dist = Enumerable.Repeat(int.MaxValue, _graph.Length).ToArray();
            dist[node1] = 0;
            pq.Enqueue((node1, 0), 0);
            while(pq.Count > 0) {
                var (node, cost) = pq.Dequeue();
                if(node == node2) 
                    return cost;
                
                foreach(var (nextNode, nextCost) in _graph[node]) {
                    if(dist[nextNode] <= cost + nextCost)
                        continue;
                    
                    dist[nextNode] = cost + nextCost;
                    pq.Enqueue((nextNode, dist[nextNode]), dist[nextNode]);
                }
            }

            return -1;
        }
    }
}
