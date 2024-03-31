using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 918
    /// title:  环形子数组的最大和
    /// problems: https://leetcode.cn/problems/maximum-sum-circular-subarray/
    /// date: 20230720
    /// </summary>
    public static class Solution918
    {
        public static int MaxSubarraySumCircular(int[] nums) {
            int length = nums.Length;
            int max = nums[0];
            int min = nums[0];
            int sum = nums[0];
            int maxSum = nums[0];
            int minSum = nums[0];
            for(int i = 1; i < length; i++){
                sum += nums[i];
                maxSum = Math.Max(maxSum + nums[i], nums[i]);
                max = Math.Max(max, maxSum);
                minSum = Math.Min(minSum + nums[i], nums[i]);
                min = Math.Min(min, minSum);
            }

            return max > 0 ? Math.Max(max, sum - min) : max;
        }
    }
}