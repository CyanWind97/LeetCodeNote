using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1800
    /// title: 最大升序子数组和
    /// problems: https://leetcode.cn/problems/maximum-ascending-subarray-sum/
    /// date: 20221007
    /// </summary>
    public static class Solution1800
    {
        public static int MaxAscendingSum(int[] nums) {
            int length = nums.Length;
            int sum = nums[0];
            int max = sum;
            
            for(int i = 1; i < length; i++){
                if(nums[i] > nums[i - 1]){
                    sum += nums[i];
                }else{
                    max = Math.Max(sum, max);
                    sum = nums[i];
                }
            }

            max = Math.Max(sum, max);

            return max;
        }
    }
}