using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2039
    /// title: 网络空闲的时刻
    /// problems: https://leetcode-cn.com/problems/the-time-when-the-network-becomes-idle/
    /// date: 20220320
    /// </summary>
    public static class Solution2039
    {
        public static int NetworkBecomesIdle(int[][] edges, int[] patience) {
            int n = patience.Length;       
            var map = new IList<int>[n];
            for (int i = 0; i < n; ++i) {
                map[i] = new List<int>();
            }
            
            foreach (int[] v in edges) {
                map[v[0]].Add(v[1]);
                map[v[1]].Add(v[0]);
            }
            
            bool[] visit = new bool[n];
            var queue = new Queue<int>();
            queue.Enqueue(0);
            visit[0] = true;
            int dist = 1;
            int result = 0;
            while (queue.Count > 0) {
                int size = queue.Count;
                for (int i = 0; i < size; i++) {
                    int curr = queue.Dequeue();
                    foreach (int v in map[curr]) {
                        if (visit[v])
                            continue;
                        
                        queue.Enqueue(v);
                        int time = patience[v] * ((2 * dist - 1) / patience[v]) + 2 * dist + 1;
                        result = Math.Max(result, time);
                        visit[v] = true;
                    }
                }
                dist++;
            }

            return result;
        }
    }
}