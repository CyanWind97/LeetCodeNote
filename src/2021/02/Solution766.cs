using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 766
    /// title: 托普利茨矩阵
    /// problems: https://leetcode-cn.com/problems/toeplitz-matrix/
    /// date: 20210222
    /// </summary>
    public static class Solution766
    {

        public static bool IsToeplitzMatrix(int[][] matrix) {
            int m = matrix.Length;
            int n = matrix[0].Length;
            for (int i = 1; i < m; i++) {
                for (int j = 1; j < n; j++) {
                    if (matrix[i][j] != matrix[i - 1][j - 1]) {
                        return false;
                    }
                }
            }
            
            return true;
        }

        public static bool IsToeplitzMatrix_1(int[][] matrix) {
            int m = matrix.Length;
            int n = matrix[0].Length;
            var list = new LinkedList<int>();
            for(int j = 0; j < n; j++){
                list.AddLast(matrix[0][j]);
            }

            for(int i = 1; i < m; i++){
                list.RemoveLast();
                var cur = list.First;
                for(int j = 1; j < n; j++){
                    if(matrix[i][j] != cur.Value)
                        return false;

                    cur = cur.Next;
                }
                list.AddFirst(matrix[i][0]);
            }

            return true;
        }
    }
}