using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1335
    /// title: 工作计划的最低难度
    /// problems: https://leetcode.cn/problems/minimum-difficulty-of-a-job-schedule/
    /// date: 20230516
    /// </summary>
    public static class Solution1335
    {
        public  static int MinDifficulty(int[] jobDifficulty, int d) {
            int length = jobDifficulty.Length;
            if(length < d)
                return -1;
            
            var dp = new int[d, length];
            dp[0, 0] = jobDifficulty[0];
            for(int i = 1; i < length; i++){
                dp[0, i] = Math.Max(dp[0, i - 1], jobDifficulty[i]);
            }

            for(int i = 1; i < d; i++){
                for(int j = i; j < length; j++){
                    int max = jobDifficulty[j];
                    dp[i, j] = int.MaxValue;
                    for(int k = j; k >= i; k--){
                        max = Math.Max(max, jobDifficulty[k]);
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, k - 1] + max);
                    }
                }
            }

            return dp[d - 1, length - 1];
        }
    }
}