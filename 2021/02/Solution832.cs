namespace LeetCodeNote
{
    /// <summary>
    /// no: 832
    /// title: 翻转图像
    /// problems: https://leetcode-cn.com/problems/flipping-an-image/
    /// date: 20210224
    /// </summary>
    public static class Solution832
    {
        public static int[][] FlipAndInvertImage(int[][] A) {
            int m = A.Length;
            int n = A[0].Length;
            for(int i = 0; i < m; i++){
                for(int j = 0; j < (n + 1) / 2; j++){
                    (A[i][j], A[i][n - j - 1]) = (1 - A[i][n - j - 1], 1 - A[i][j]);
                }
            }
            
            return A;
        }

        // 参考解答 优化
        public static int[][] FlipAndInvertImage_1(int[][] A) {
            int m = A.Length;
            int n = A[0].Length;
            for(int i = 0; i < m; i++){
                for(int j = 0; j < (n + 1) / 2; j++){
                    if(A[i][j] == A[i][n - j - 1]){
                        if(A[i][j] == 0){
                            A[i][j] = 1;
                            A[i][n - j - 1] = 1;
                        }else{
                            A[i][j] = 0;
                            A[i][n - j - 1] = 0;
                        }
                    }
                }
            }
            
            return A;
        }
    }
}