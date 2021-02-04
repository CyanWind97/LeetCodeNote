using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 634
    /// title: 子数组最大平均数 I
    /// problems: https://leetcode-cn.com/problems/maximum-average-subarray-i/
    /// date: 20210204
    /// </summary>
    public static class Solution634
    {
        public static double FindMaxAverage(int[] nums, int k) {
            int length = nums.Length;
            int curSum = 0;
            int maxSum = 0;

            for(int i = 0; i < k; i++){
                curSum += nums[i];
            }

            maxSum = curSum;

            for(int i = k; i < length; i++){
                curSum += nums[i] - nums[i - k];
                if(curSum > maxSum)
                    maxSum = curSum;
            }

            return  (double)maxSum / (double)k;
        }
    }
}