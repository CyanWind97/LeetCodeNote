using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 808
    /// title: 分汤
    /// problems: https://leetcode.cn/problems/soup-servings/
    /// date: 20221121
    /// </summary>
    public static class Solution808
    {
        // 参考解答
        // 动态规划
        public static double SoupServings(int n) {
            n = (int)(Math.Ceiling((double)n / 25));
            if(n >= 179)
                return 1.0;
            
            var dp = new double[n + 1, n + 1];
            
            dp[0, 0] = 0.5;
            for(int i = 1; i <= n; i++){
                dp[0, i] = 1.0;
            }

            for(int i = 1; i <= n; i++){
                for(int j = 1; j <= n; j++){
                    dp[i, j] = (dp[Math.Max(0, i - 4), j] 
                            + dp[Math.Max(0, i - 3), Math.Max(0, j - 1)] 
                            + dp[Math.Max(0, i - 2), Math.Max(0, j - 2)] 
                            + dp[Math.Max(0, i - 1), Math.Max(0, j - 3)]) 
                            / 4.0;
                }
            }

            return dp[n, n];
        }
    }
}