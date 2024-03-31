using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 279
    /// title: 完全平方数
    /// problems: https://leetcode-cn.com/problems/perfect-squares/
    /// date: 20210611
    /// </summary>
    public static class Solution279
    {
        public static int NumSquares(int n) {
            int max = (int)Math.Sqrt(n);
            int[] dp = new int[n + 1];
            
            Array.Fill(dp, n);

            for(int i = 1; i <= max; i++){
                dp[i * i] = 1;
                for(int j = i * i + 1; j <= n; j++){
                    dp[j] = Math.Min(dp[j], dp[j - i * i] + 1);
                }
            }

            return dp[n];
        }

        // 数学法
        public static int NumSquares_1(int n) {
            // 判断是否为完全平方数
            bool IsPerfectSquare(int x) {
                int y = (int) Math.Sqrt(x);
                return y * y == x;
            }

            // 判断是否能表示为 4^k*(8m+7)
            bool CheckAnswer4(int x) {
                while (x % 4 == 0) {
                    x /= 4;
                }
                return x % 8 == 7;
            }

            if (IsPerfectSquare(n)) {
                return 1;
            }
            if (CheckAnswer4(n)) {
                return 4;
            }
            for (int i = 1; i * i <= n; i++) {
                int j = n - i * i;
                if (IsPerfectSquare(j)) {
                    return 2;
                }
            }
            return 3;
        }
    }

}