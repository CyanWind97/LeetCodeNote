using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1140
    /// title: 石子游戏 II
    /// problems: https://leetcode.cn/problems/stone-game-ii/
    /// date: 20230222
    /// </summary>
    public static class Solution1140
    {
        // 参考解答
        // 动态规划
        public static int StoneGameII(int[] piles) {
            int length = piles.Length;
            int sum =0;
            var dp = new int[length, length + 1];
            for(int i = length - 1; i >= 0; i--){
                sum += piles[i];
                for(int m = 1; m <= length; m++){
                    if(i + 2 * m >= length){
                        dp[i, m] = sum;
                    }else{
                        for(int x = 1; x <= 2 * m; x++){
                            dp[i, m] = Math.Max(dp[i, m], sum - dp[i + x, Math.Max(m, x)]);
                        }
                    }
                }
            }

            return dp[0, 1];
        }
    }
}