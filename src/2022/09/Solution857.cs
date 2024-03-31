using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 857
    /// title: 雇佣 K 名工人的最低成本
    /// problems: https://leetcode.cn/problems/minimum-cost-to-hire-k-workers/
    /// date: 20220911
    /// </summary>
    public static class Solution857
    {
        // 参考解答
        // 贪心 + 优先队列
        public static double MincostToHireWorkers(int[] quality, int[] wage, int k) {
            int length = quality.Length;
            int[] h = Enumerable.Range(0, length).ToArray();
            Array.Sort(h, (a, b) => quality[b] * wage[a] - quality[a] * wage[b]);

            double result = 1e9;
            double totalq = 0.0;
            var pq = new PriorityQueue<int, int>();
            for(int i = 0; i < k - 1; i++){
                totalq += quality[h[i]];
                pq.Enqueue(quality[h[i]], -quality[h[i]]);
            }

            for(int i = k - 1; i < length; i++){
                int index = h[i];
                totalq += quality[index];
                pq.Enqueue(quality[index], -quality[index]);
                var totalc = ((double) wage[index]  / quality[index]) * totalq;
                result = Math.Min(result, totalc);
                totalq -= pq.Dequeue();
            }

            return result;
        }
    }
}