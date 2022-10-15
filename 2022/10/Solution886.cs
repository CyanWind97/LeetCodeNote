using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 886
    /// title: 可能的二分法
    /// problems: https://leetcode.cn/problems/possible-bipartition/
    /// date: 20221016
    /// </summary>
    public static class Solution886
    {
        // 参考解答
        // 广度优先
        public static bool PossibleBipartition(int n, int[][] dislikes) {
            int[] parent = new int[n + 1];
            var g = new IList<int>[n + 1];
            for (int i = 0; i <= n; ++i) {
                g[i] = new List<int>();
            }

            foreach (int[] p in dislikes) {
                g[p[0]].Add(p[1]);
                g[p[1]].Add(p[0]);
            }

            for (int i = 1; i <= n; ++i) {
                if (parent[i] != 0) 
                    continue;

                var queue = new Queue<int>();
                queue.Enqueue(i);
                parent[i] = 1;
                while (queue.Count > 0) {
                    int t = queue.Dequeue();
                    foreach (int next in g[t]) {
                        if (parent[next] > 0 && parent[next] == parent[t]) 
                            return false;
                        
                        if (parent[next] == 0) {
                            parent[next] = 3 ^ parent[t];
                            queue.Enqueue(next);
                        }
                    }
                }
            }

            return true;
        }
    }
}