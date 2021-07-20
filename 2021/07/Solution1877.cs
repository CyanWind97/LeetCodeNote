using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1877
    /// title: 数组中最大数对和的最小值
    /// problems: https://leetcode-cn.com/problems/minimize-maximum-pair-sum-in-array/
    /// date: 20210720
    /// </summary>
    public static class Solution1877
    {
        public static int MinPairSum(int[] nums) {
            Array.Sort(nums);
            int length = nums.Length;
            int result = nums[0] + nums[length - 1];
            for(int i = 1; i < length / 2; i++){
                result = Math.Max(result, nums[i] + nums[length - i - 1]);
            }

            return result;
        }
    }
}