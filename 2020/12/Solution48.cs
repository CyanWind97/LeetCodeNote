namespace LeetCodeNote
{
    /// <summary>
    /// no: 48
    /// title: 旋转图像
    /// problems: https://leetcode-cn.com/problems/rotate-image/
    /// date: 20201219
    /// </summary>
    public static class Solution48
    {
        public static void Rotate(int[][] matrix) {
            int n = matrix.Length;
            for(int i = 0; i < n / 2; i++) {
                for(int j = i; j < n - i - 1; j++) {
                    int tmp = matrix[i][j];
                    matrix[i][j] = matrix[n - j -1][i];
                    matrix[n - j - 1][i] = matrix[n - i - 1][n - j - 1];
                    matrix[n - i - 1][n - j - 1] = matrix[j][n - i - 1];
                    matrix[j][n - i - 1] = tmp;
                }
            }
        }
    }
}