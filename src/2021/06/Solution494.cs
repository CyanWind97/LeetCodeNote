using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 494
    /// title: 目标和
    /// problems: https://leetcode-cn.com/problems/target-sum/
    /// date: 20210607
    /// </summary>
    public static partial class Solution494
    {
        public static int FindTargetSumWays(int[] nums, int target) {
            int length = nums.Length;
            int sum = nums.Sum();
            
            if(target < 0)
                target = -target;
            
            if(target > sum)
                return 0;

            int[] dp = new int[sum + 1];
            dp[sum] = 1;

            foreach(var num in nums){
                for(int i = target; i <= sum - 2 * num; i++){
                    dp[i] =  dp[i] + dp[i + 2 * num];
                }
            }

            return dp[target];
        }
    }
}