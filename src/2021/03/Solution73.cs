namespace LeetCodeNote
{
    /// <summary>
    /// no: 73
    /// title: 矩阵置零
    /// problems: https://leetcode-cn.com/problems/set-matrix-zeroes/
    /// date: 20210321
    /// </summary>
    public static class Solution73
    {
        // 参考解答
        public  static void SetZeroes(int[][] matrix) {
            int m = matrix.Length;
            int n = matrix[0].Length;
            bool flag = false;

            for(int i = 0; i < m; i++){
                if(matrix[i][0] == 0)
                    flag = true;

                for(int j = 1; j < n; j++){
                    if(matrix[i][j] == 0)
                        matrix[i][0] = matrix[0][j] = 0;
                }
            }

            for(int i = m - 1; i >= 0; i--){
                for(int j = 1; j < n; j++){
                    if(matrix[i][0] == 0 || matrix[0][j] == 0)
                        matrix[i][j] = 0;
                }
                if(flag)
                    matrix[i][0] = 0;
            }
        } 
    }
}