namespace LeetCodeNote
{
    /// <summary>
    /// no: 867
    /// title: 转置矩阵
    /// problems: https://leetcode-cn.com/problems/transpose-matrix/
    /// date: 20210225
    /// </summary>
    public static class Solution867
    {
        public static int[][] Transpose(int[][] matrix) {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[][] result = new int[n][];
            for(int i = 0; i < n; i++){
                result[i] = new int[m];
                for(int j = 0; j < m; j++){
                    result[i][j] = matrix[j][i];
                }
            }

            return result;
        }
    }
}