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
            long[,] dp = new long[arrLen, steps];
            dp[0, 1] = 1;
            dp[1, 1] = 1;

            int mod = 1000000007;

            for(int i = 2; i < steps; i++){
                dp[0, i] = (dp[0, i - 1] + dp[1, i - 1]) % mod;
                for(int j = 1; j < arrLen - 1; j++){
                    dp[j, i] = (dp[j - 1, i - 1] + dp[j, i - 1] + dp[j + 1, i - 1]) % mod;
                }
                dp[arrLen - 1, i] = (dp[arrLen - 2, i] + dp[arrLen - 1, i]) % mod;
            }

            return (int)((dp[0, steps - 1] + dp[1, steps - 1]) % mod);
        }
    }
}