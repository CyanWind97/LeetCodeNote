namespace LeetCodeNote
{
    /// <summary>
    /// no: 59
    /// title: 螺旋矩阵 II
    /// problems: https://leetcode-cn.com/problems/spiral-matrix-ii/
    /// date: 20210316
    /// </summary>
    public static partial class Solution59
    {
        public static int[][] GenerateMatrix(int n) {
            int[][] matrix = new int[n][];
            int count = 1;

            for(int i = 0; i < n; i++){
                matrix[i] = new int[n];
            }
            
            for(int k = 0; k <= n / 2; k++){
                for(int j = k; j <= n - 1 - k; j++){
                   matrix[k][j] = count++;
                }

                for(int i = k + 1;  i <= n - k - 1; i++){
                    matrix[i][n - k - 1] = count++;
                }

                if(2 * k < n - 1){
                    for(int j = n - k - 2; j > k; j--){
                        matrix[n - k - 1][j] = count++;
                    }

                    for(int i =  n - k - 1;  i > k; i--){
                        matrix[i][k] = count++;
                    }
                }
            }
        
            return matrix;
        }
    }
}