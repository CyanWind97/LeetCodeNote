namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 48
    /// title: 旋转图像
    /// problems: https://leetcode-cn.com/problems/rotate-image/
    /// date: 20220507
    /// priority: 0018
    /// time: 00:13:55.01
    /// </summary>
    public class CodeTop48
    {
        public static void Rotate(int[][] matrix) {
            int n = matrix.Length;
            for(int i = 0; i < n / 2; i++){
                for(int j = i; j < n - i - 1; j++){
                    (matrix[i][j], matrix[j][n - i - 1],  matrix[n - i - 1][n - j - 1], matrix[n - j - 1][i])
                    =  (matrix[n - j - 1][i], matrix[i][j], matrix[j][n - i - 1],  matrix[n - i - 1][n - j - 1]);
                }
            }
        }
    }
}