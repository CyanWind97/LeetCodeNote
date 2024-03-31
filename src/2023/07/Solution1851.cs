using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1851
    /// title:  包含每个查询的最小区间
    /// problems: https://leetcode.cn/problems/minimum-interval-to-include-each-query/
    /// date: 20230718
    /// </summary>
    public static class Solution1851
    {
        // 参考解答
        public static int[] MinInterval(int[][] intervals, int[] queries) {
           int[] qindex = new int[queries.Length];
            for (int idx = 0; idx < queries.Length; idx++) {
                qindex[idx] = idx;
            }
            Array.Sort(qindex, (i, j) => queries[i] - queries[j]);
            Array.Sort(intervals, (i, j) => i[0] - j[0]);
            var pq = new PriorityQueue<int[], int>();
            int[] res = new int[queries.Length];
            Array.Fill(res, -1);
            int i = 0;
            foreach (int qi in qindex) {
                while (i < intervals.Length && intervals[i][0] <= queries[qi]) {
                    pq.Enqueue(new int[]{intervals[i][1] - intervals[i][0] + 1, intervals[i][0], intervals[i][1]}, intervals[i][1] - intervals[i][0] + 1);
                    i++;
                }
                while (pq.Count > 0 && pq.Peek()[2] < queries[qi]) {
                    pq.Dequeue();
                }
                if (pq.Count > 0) {
                    res[qi] = pq.Peek()[0];
                }
            }

            return res;
        }
    }
}