using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 115
    /// title: 重建序列
    /// problems: https://leetcode.cn/problems/ur2n8P/
    /// date: 20220723
    /// type: 剑指Offer lcof
    /// </summary>
    public static class Solution_lcof_115
    {
        public static bool SequenceReconstruction(int[] nums, int[][] sequences) {
            int length = nums.Length;
            var indegrees = new int[length + 1];
            var graph = indegrees.Select(i => new HashSet<int>()).ToArray();

            foreach (var sequence in sequences) {
                int size = sequence.Length;
                for (int i = 1; i < size; i++) {
                    int prev = sequence[i - 1], next = sequence[i];
                    if (graph[prev].Add(next)) 
                        indegrees[next]++;
                }
            }

            var queue = new Queue<int>();
            for (int i = 1; i <= length; i++) {
                if (indegrees[i] == 0) 
                    queue.Enqueue(i);
            }

            while (queue.Count > 0) {
                if (queue.Count > 1) 
                    return false;
                
                int num = queue.Dequeue();
                var set = graph[num];
                foreach (int next in set) {
                    indegrees[next]--;
                    if (indegrees[next] == 0) 
                        queue.Enqueue(next);
                }
            }

            return true;
        }
    }
}