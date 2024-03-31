using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 790
    /// title: 多米诺和托米诺平铺
    /// problems: https://leetcode.cn/problems/domino-and-tromino-tiling/
    /// date: 20221112
    /// </summary> 
    public static class Solution790
    {
        // 参考解答
        // 动态规划
        public  static int NumTilings(int n) {
            int MOD = 1000000007;
            var dp = new int[n + 1, 4];
            dp[0, 3] = 1;
            for(int i = 1; i <= n; i++){
                dp[i, 0] = dp[i - 1, 3];
                dp[i, 1] = (dp[i - 1, 0] + dp[i - 1, 2]) % MOD;
                dp[i, 2] = (dp[i - 1, 0] + dp[i - 1, 1]) % MOD;
                dp[i, 3] = (((dp[i - 1, 0] + dp[i - 1, 1]) % MOD + dp[i - 1, 2]) % MOD + dp[i - 1, 3]) % MOD;
            }

            return dp[n, 3];
        }
    }
}