using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 01.08.
    /// title: 01.08. 零矩阵
    /// problems: https://leetcode.cn/problems/zero-matrix-lcci/
    /// date: 20220930
    /// type: 面试题 lcci
    /// </summary>
    public class Solution_lcci_01_08
    {
        public static void SetZeroes(int[][] matrix) {
            int m = matrix.Length;
            int n = matrix[0].Length;

            var rows = new bool[m];
            var cols = new bool[n];

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    if(matrix[i][j] == 0){
                        rows[i] = true;
                        cols[j] = true;
                    }
                }
            }

            for(int i = 0; i < m; i++){
                if(rows[i])
                    Array.Fill(matrix[i], 0);
            }

            for(int j = 0; j < n; j++){
                if(cols[j]){
                    for(int i = 0; i < m; i++){
                        matrix[i][j] = 0;
                    }
                }
            }
        }
    }
}