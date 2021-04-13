using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 264
    /// title: 丑数 II
    /// problems: https://leetcode-cn.com/problems/ugly-number-ii/
    /// date: 20210411
    /// </summary>
    public static class Solution264
    {
        // 参考解答
        public static int NthUglyNumber(int n) {
            int[] dp = new int[n + 1];
            dp[1] = 1;
            int dp2 = 1, dp3 = 1, dp5 = 1;
            for(int i = 2; i <= n; i++)
            {
                int num2 = dp[dp2] * 2;
                int num3 = dp[dp3] * 3;
                int num5 = dp[dp5] * 5;

                dp[i] = Math.Min(Math.Min(num2, num3), num5);
                
                if(num2 == dp[i])
                    dp2++;
                
                if(num3 == dp[i])
                    dp3++;
                
                if(num5 == dp[i])
                    dp5++;
            }
            
            
            return dp[n];
        }
    }
}