using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1749
    /// title: 任意子数组和的绝对值的最大值
    /// problems: https://leetcode.cn/problems/maximum-absolute-sum-of-any-subarray/
    /// date: 20230808
    /// </summary>
    public static class Solution1749
    {
        public static int MaxAbsoluteSum(int[] nums) {
            int length = nums.Length;
            int max = nums[0];
            int min = nums[0];
            int result = Math.Abs(nums[0]);
            
            for(int i = 1; i < length; i++){
                if (max + nums[i] < max){
                    result = Math.Max(result, Math.Abs(max));
                    max += nums[i];
                }else if(max + nums[i] < nums[i]){
                    max = nums[i];
                }else{
                    max += nums[i];
                }

                if (min + nums[i] > min){
                    result = Math.Max(result, Math.Abs(min));
                    min += nums[i];
                }else if(min + nums[i] > nums[i]){
                    min = nums[i];
                }else{
                    min += nums[i];
                }
            }

            return Math.Max(result, Math.Max(Math.Abs(max), Math.Abs(min)));
        }
    }
}