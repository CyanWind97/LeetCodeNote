using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1269
    /// title:  停在原地的方案数
    /// problems: https://leetcode-cn.com/problems/number-of-ways-to-stay-in-the-same-place-after-some-steps/
    /// date: 20210513
    /// </summary>
    public static class Solution1269
    {
        public static int NumWays(int steps, int arrLen) {
            const int mod = 1000000007;
            int maxColumn = Math.Min(arrLen - 1, steps);
            int[,] dp = new int[maxColumn + 1, steps + 1];
            dp[0, 0] = 1;


            for(int i = 1; i <= steps; i++){
                for(int j = 0; j <= maxColumn; j++){
                    dp[j, i] = dp[j, i - 1];
                    if(j - 1 >= 0)
                        dp[j, i] = (dp[j - 1, i - 1] + dp[j, i]) % mod;
                    
                    if(j + 1 <= maxColumn)
                        dp[j, i] = (dp[j + 1, i - 1] + dp[j, i]) % mod;
                }
            }

            return dp[0, steps];
        }
    }
}