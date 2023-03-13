using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1605
    /// title: 给定行和列的和求可行矩阵
    /// problems: https://leetcode.cn/problems/find-valid-matrix-given-row-and-column-sums/
    /// date: 20230314
    /// </summary>
    public static class Solution1605
    {
        public static int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
            int m = rowSum.Length;
            int n = colSum.Length;

            var rowQueue = new PriorityQueue<(int Value, int Index), int>();
            var colQueue = new PriorityQueue<(int Value, int Index), int>();

            for(int i = 0; i < m; i++){
                rowQueue.Enqueue((rowSum[i], i), rowSum[i]);
            }

            for(int j = 0; j < n; j++){
                colQueue.Enqueue((colSum[j], j), colSum[j]);
            }
            
            var result = Enumerable.Range(0, m)
                            .Select(i => new int[n])
                            .ToArray();

            while(rowQueue.Count > 0 && colQueue.Count > 0){
                var row = rowQueue.Dequeue();
                var col = colQueue.Dequeue();
                
                int value = Math.Min(row.Value, col.Value);
                result[row.Index][col.Index] = value;

                row.Value -= value;
                if(row.Value > 0)
                    rowQueue.Enqueue(row, row.Value);
                
                col.Value -= value;
                if(col.Value > 0)
                    colQueue.Enqueue(col, col.Value);
            }

            return result;
        }
    }
}