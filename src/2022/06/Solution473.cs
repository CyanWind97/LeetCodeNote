using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 473
    /// title: 火柴拼正方形
    /// problems: https://leetcode.cn/problems/matchsticks-to-square/
    /// date: 20220601
    /// </summary>
    public static class Solution473
    {
        // 参考解答 状态压缩 + 动态规划
        public static bool Makesquare(int[] matchsticks) {
            int total = matchsticks.Sum();
            if(total % 4 != 0)
                return false;
            
            int side = total / 4;
            int length = matchsticks.Length;
            var dp = new int[1 << length];
            Array.Fill(dp, - 1);
        
            dp[0] = 0;
            for(int s = 1; s < (1 << length); s++){
                for(int k = 0; k < length; k++){
                    if((s & (1 << k)) == 0)
                        continue;
                    
                    int s1 = s & ~(1 << k);
                    if(dp[s1] >= 0 && dp[s1] + matchsticks[k] <= side){
                        dp[s] = (dp[s1] + matchsticks[k]) % side;
                        break;
                    }
                }
            }

            return dp[(1 << length) - 1] == 0;
        }
    }
}