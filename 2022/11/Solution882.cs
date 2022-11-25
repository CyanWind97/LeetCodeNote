using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 882
    /// title: 细分图中的可到达节点
    /// problems: https://leetcode.cn/problems/reachable-nodes-in-subdivided-graph/
    /// date: 20221126
    /// </summary>
    public static class Solution882
    {   
        // 参考解答
        // dijkstra
        public static int ReachableNodes(int[][] edges, int maxMoves, int n) {
            int Encode(int u, int v, int n) {
                return u * n + v;
            }

            IList<int[]>[] adList = new IList<int[]>[n];
            for (int i = 0; i < n; i++) {
                adList[i] = new List<int[]>();
            }
            foreach (int[] edge in edges) {
                int u = edge[0], v = edge[1], nodes = edge[2];
                adList[u].Add(new int[]{v, nodes});
                adList[v].Add(new int[]{u, nodes});
            }
            IDictionary<int, int> used = new Dictionary<int, int>();
            ISet<int> visited = new HashSet<int>();
            int reachableNodes = 0;
            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
            pq.Enqueue(new int[]{0, 0}, 0);

            while (pq.Count > 0 && pq.Peek()[0] <= maxMoves) {
                int[] pair = pq.Dequeue();
                int step = pair[0], u = pair[1];
                if (!visited.Add(u)) {
                    continue;
                }
                reachableNodes++;
                foreach (int[] next in adList[u]) {
                    int v = next[0], nodes = next[1];
                    if (nodes + step + 1 <= maxMoves && !visited.Contains(v)) {
                        pq.Enqueue(new int[]{nodes + step + 1, v}, nodes + step + 1);
                    }
                    used.Add(Encode(u, v, n), Math.Min(nodes, maxMoves - step));
                }
            }

            foreach (int[] edge in edges) {
                int u = edge[0], v = edge[1], nodes = edge[2];
                int key1 = Encode(u, v, n), key2 = Encode(v, u, n);
                reachableNodes += Math.Min(nodes, (used.ContainsKey(key1) ? used[key1] : 0) + (used.ContainsKey(key2) ? used[key2] : 0));
            }
            return reachableNodes;
        }
    }
}