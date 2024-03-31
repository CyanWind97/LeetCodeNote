namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 62
    /// title:  不同路径
    /// problems: https://leetcode.cn/problems/unique-paths/
    /// date: 20220517
    /// priority: 0077
    /// time: 00:04:01.51
    /// </summary>
    public static class CodeTop62
    {
        public static int UniquePaths(int m, int n) {
            var dp = new int[m + 1, n + 1];
            
            dp[0, 1] = 1;

            for(int i = 1; i <= m; i++){
                for(int j = 1; j <= n; j++){
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m, n];
        }

         // 杨辉三角（二项式系数） 数学解
        public static int UniquePaths_1(int m, int n) {
            if(n > m)
                return UniquePaths_1(n, m); 

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

        // 官方解答
        public static int UniquePaths_2(int m, int n) {
            long result = 1;
            for(int x = n, y = 1; y < m; x++, y++) {
                result = result * x / y;
            }

            return (int)result;
        }
    }
}