using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 847
    /// title: 访问所有节点的最短路径
    /// problems: https://leetcode-cn.com/problems/shortest-path-visiting-all-nodes/
    /// date: 20210806
    /// </summary>
    public static class Solution847
    {
        // 参考解答 状态压缩 + 广度优先搜索
        public static int ShortestPathLength(int[][] graph) {
            int n = graph.Length;
            var queue = new Queue<(int U, int Mask, int Dist)>();
            bool[,] seen = new bool[n, 1 << n];
            for (int i = 0; i < n; ++i) {
                queue.Enqueue((i, 1 << i, 0));
                seen[i, 1 << i] = true;
            }

            int ans = 0;
            while (queue.Count > 0) {
                var cur = queue.Dequeue();
                if (cur.Mask == (1 << n) - 1) {
                    ans = cur.Dist;
                    break;
                }
                // 搜索相邻的节点
                foreach (int v in graph[cur.U]) {
                    // 将 mask 的第 v 位置为 1
                    int maskV = cur.Mask | (1 << v);
                    if (!seen[v, maskV]) {
                        queue.Enqueue((v, maskV, cur.Dist + 1));
                        seen[v, maskV] = true;
                    }
                }
            }
            return ans;
        }
    }
}