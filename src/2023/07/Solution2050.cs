using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2500
    /// title:  并行课程 III
    /// problems: https://leetcode.cn/problems/parallel-courses-iii/
    /// date: 20230728
    /// </summary>
    public static class Solution2050
    {
        public static int MinimumTime(int n, int[][] relations, int[] time) {
            var degrees = new int[n];
            var graphs = Enumerable.Range(0, n)
                            .Select(_ => new List<int>())
                            .ToArray();
            
            foreach(var relation in relations){
                (var x, var y) = (relation[0] - 1, relation[1] - 1);
                degrees[y]++;
                graphs[x].Add(y);
            }

            var queue = new Queue<int>();
            var preMonths = new int[n];
            var result = 0;
            for(int i = 0; i < n; i++){
                if (degrees[i] == 0)
                    queue.Enqueue(i);
            }

            while(queue.Count > 0){
                var node = queue.Dequeue();
                result = Math.Max(result, preMonths[node] + time[node]);
                foreach(var next in graphs[node]){
                    preMonths[next] = Math.Max(preMonths[next], preMonths[node] + time[node]);
                    degrees[next]--;
                    if(degrees[next] == 0)
                        queue.Enqueue(next);
                }
            }

            return result;
        }
    }
}