namespace LeetCodeNote
{
    /// <summary>
    /// no: 240
    /// title: 搜索二维矩阵 II
    /// problems: https://leetcode-cn.com/problems/search-a-2d-matrix-ii/
    /// date: 20211025
    /// </summary>
    public static class Solution240
    {
        public static  bool SearchMatrix(int[][] matrix, int target) {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int i = 0;
            int j = n - 1;

            while(i < m && j >= 0){
                if (matrix[i][j] == target)
                    return true;
                else if (matrix[i][j] < target)
                    i++;
                else
                    j--;
            }

            return false;
        }
    }
}