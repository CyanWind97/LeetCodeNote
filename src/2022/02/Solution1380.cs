using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1380
    /// title: 矩阵中的幸运数
    /// problems: https://leetcode-cn.com/problems/lucky-numbers-in-a-matrix/
    /// date: 20220215
    /// </summary>
    public static class Solution1380
    {
        public static IList<int> LuckyNumbers (int[][] matrix) {
            int m = matrix.Length;
            int n = matrix[0].Length;

            var rows = new int[m];
            var cols = new int[n];
            Array.Fill(rows, int.MaxValue);

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    rows[i] = Math.Min(rows[i], matrix[i][j]);
                    cols[j] = Math.Max(cols[j], matrix[i][j]);
                }
            }

            return rows.Intersect(cols).ToList();
        }

        // 参考思路 数学论证，只有一个值
        public static IList<int> LuckyNumbers_1 (int[][] matrix) {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int row = 0;
            int min = int.MaxValue;

            for(int j = 0; j < n; j++){
                int idx = 0;
                for(int i = 1; i < m; i++){
                    if(matrix[i][j] > matrix[idx][j])
                        idx = i;
                }

                if(matrix[idx][j] < min){
                    min = matrix[idx][j];
                    row = idx;
                }
            }

            return matrix[row].Any(x => x < min) ? new int[]{} : new int[]{ min };
        }
    }
}