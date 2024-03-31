using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 713
    /// title:  乘积小于 K 的子数组
    /// problems: https://leetcode-cn.com/problems/subarray-product-less-than-k/
    /// date: 20220505
    /// </summary>
    public static class Solution713
    {
        public static int NumSubarrayProductLessThanK(int[] nums, int k) {
            int length = nums.Length;
            int count = 0;
            int product = 1;
            int left = 0;

            for (int right = 0; right < length; right++) {
                product *= nums[right];
                
                while (left <= right && product >= k) {
                    product /= nums[left];
                    left++;
                }

                count += right - left + 1;
            }

            return count;
        }
    }
}