using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1439
    /// title: 有序矩阵中的第 k 个最小数组和
    /// problems: https://leetcode.cn/problems/find-the-kth-smallest-sum-of-a-matrix-with-sorted-rows/
    /// date: 20230528
    /// </summary>
    public static class Solution1439
    {
        // 参考解答 
        // 小根堆
        public static int KthSmallest(int[][] mat, int k) {
            int[] Merge(int[] f, int[] g, int k) {
                if (g.Length > f.Length)
                    return Merge(g, f, k);

                var pq = new PriorityQueue<int[], int>();
                for (int i = 0; i < g.Length; ++i) {
                    pq.Enqueue(new int[]{0, i, f[0] + g[i]}, f[0] + g[i]);
                }

                var list = new List<int>();
                while (k > 0 && pq.Count > 0) {
                    int[] entry = pq.Dequeue();
                    list.Add(entry[2]);
                    if (entry[0] + 1 < f.Length) {
                        pq.Enqueue(new int[]{entry[0] + 1, entry[1], f[entry[0] + 1] + g[entry[1]]}, f[entry[0] + 1] + g[entry[1]]);
                    }
                    --k;
                }

                return list.ToArray();
            }
            
            int m = mat.Length;
            int[] prev = mat[0];
            for (int i = 1; i < m; ++i) {
                prev = Merge(prev, mat[i], k);
            }

            return prev[k - 1];
        }
    }
}