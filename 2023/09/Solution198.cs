using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 198
    /// title: 打家劫舍
    /// problems: https://leetcode.cn/problems/house-robber/?envType=daily-question&envId=2023-09-16
    /// date: 20230916
    /// </summary>
    public static class Solution198
    {
        public static int Rob(int[] nums) {
            int length = nums.Length;
            if(length == 1)
                return nums[0];
            
            var dp = new int[length + 1];
            dp[0] = 0;
            dp[1] = nums[0];
            dp[2] = nums[1];

            for(int i = 2; i < length; i++){
                dp[i + 1] = Math.Max(dp[i - 1], dp[i - 2]) + nums[i];
            }


            return Math.Max(dp[length], dp[length - 1]);
        }
    }
}