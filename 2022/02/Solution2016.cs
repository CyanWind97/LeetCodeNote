using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2016
    /// title:  增量元素之间的最大差值
    /// problems: https://leetcode-cn.com/problems/maximum-difference-between-increasing-elements/
    /// date: 20220226
    /// </summary>
    public static class Solution2016
    {
        public static int MaximumDifference(int[] nums) {
            int length = nums.Length;
            int result = -1;
            int premin = nums[0];

            for (int i = 1; i < length; ++i) {
                if (nums[i] > premin) 
                    result = Math.Max(result, nums[i] - premin);
                else
                    premin = nums[i];
            }
            
            return result;
        }
    }
}