namespace LeetCodeNote
{
    /// <summary>
    /// no: 304
    /// title: 二维区域和检索 - 矩阵不可变
    /// problems: https://leetcode-cn.com/problems/range-sum-query-2d-immutable/
    /// date: 20210302
    /// </summary>
    public static class Solution304
    {
        public class NumMatrix {
            
            private int[,] sums;

            public NumMatrix(int[][] matrix) {
                int m = matrix.Length;
                if(m == 0)
                    return;
                int n = matrix[0].Length;
                sums = new int[m + 1, n + 1];
                for(int i = 0; i < m; i++){
                    sums[i, 0] = 0;
                }

                for(int j = 1; j < n; j++){
                    sums[0, j] = 0;
                }

                for(int i = 0; i < m; i++){
                    for(int j = 0; j < n; j++){
                        sums[i + 1, j + 1] =  matrix[i][j] + sums[i, j + 1] + sums[i + 1, j] - sums[i , j];
                    }
                }
            }
            
            public int SumRegion(int row1, int col1, int row2, int col2) {
                if(sums is null)
                    return 0;

                return sums[row2 + 1, col2 + 1] - sums[row1, col2 + 1] - sums[row2 + 1, col1]  + sums[row1, col1];
            }
        }
    }
}