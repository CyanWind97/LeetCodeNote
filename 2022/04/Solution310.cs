using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 310
    /// title: 最小高度树
    /// problems: https://leetcode-cn.com/problems/minimum-height-trees/
    /// date: 20220406
    /// </summary>
    public static partial class Solution310
    {
        // 参考解答 广度优先
        public static IList<int> FindMinHeightTrees(int n, int[][] edges) {
            var result = new List<int>();
            if (n == 1) {
                result.Add(0);
                return result;
            }

            var adj = new IList<int>[n];
            for (int i = 0; i < n; i++) {
                adj[i] = new List<int>();
            }
            foreach (int[] edge in edges) {
                adj[edge[0]].Add(edge[1]);
                adj[edge[1]].Add(edge[0]);
            }

            int[] parent = new int[n];
            Array.Fill(parent, -1);

            int FindLongestNode(int u) {
                var queue = new Queue<int>();
                bool[] visit = new bool[n];
                queue.Enqueue(u);
                visit[u] = true;
                int node = -1;
        
                while (queue.Count > 0) {
                    int curr = queue.Dequeue();
                    node = curr;
                    foreach (int v in adj[curr]) {
                        if (!visit[v]) {
                            visit[v] = true;
                            parent[v] = curr;
                            queue.Enqueue(v);
                        }
                    }
                }
                return node;
            }

            /* 找到与节点 0 最远的节点 x */
            int x = FindLongestNode(0);
            /* 找到与节点 x 最远的节点 y */
            int y = FindLongestNode(x);
            /* 求出节点 x 到节点 y 的路径 */
            IList<int> path = new List<int>();
            parent[x] = -1;
            while (y != -1) {
                path.Add(y);
                y = parent[y];
            }

            int m = path.Count;
            if (m % 2 == 0) {
                result.Add(path[m / 2 - 1]);
            }

            result.Add(path[m / 2]);
            return result;
        }
    }
}