namespace LeetCodeNote
{
    /// <summary>
    /// no: 62
    /// problems: https://leetcode-cn.com/problems/unique-paths/submissions/
    /// date: 20201209
    /// </summary>
    public static class Solution62
    {
        
        // 杨辉三角（二项式系数） 数学解
        public static int UniquePaths(int m, int n) {
            if(n > m)
                return UniquePaths(n, m); 

            long result = 1;
            int row = m + n - 2;
            int num = row;
            for(; num >=  row - n + 2; num--) {
                result *= num;
            }

            for(num = n - 1; num >= 2; num--) {
                result /= num;
            }

            return (int)result;
        }

        // 动态规划
        public static int UniquePaths_1(int m, int n) {

            int[ , ] matrix = new int[m, n];
            
            for(int i = 0; i < m; i++) {
                matrix[i, 0] = 1;
            }

            for(int j = 1; j < n; j++) {
                matrix[0, j] = 1;
            }

            for(int i = 1; i < m; i++) {
                for(int j = 1; j < n; j++) {
                    matrix[i,j] = matrix[i-1, j] + matrix[i,j-1];
                }
            }


            return matrix[m -1, n - 1];
        }

        // 官方解答
        public static int UniquePaths_2(int m, int n) {
            if(n > m)
                return UniquePaths_2(n, m); 

            long result = 1;
            for(int x = m, y = 1; y < n; x++, y++) {
                result = result * x / y;
            }

            return (int)result;
        }

    }
}