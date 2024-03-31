using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2760
    /// title: 最长奇偶子数组
    /// problems: https://leetcode.cn/problems/longest-even-odd-subarray-with-threshold/description/?envType=daily-question&envId=2023-11-16
    /// date: 20231116
    /// </summary>
    public static class Solution2760
    {
        public static int LongestAlternatingSubarray(int[] nums, int threshold) {
            int length = nums.Length;
            int result = 0;

            for(int i = 0; i < length; i++){

                while(i < length && nums[i] > threshold && nums[i] % 2 != 0)
                    i++;
                
                int count = 0;
                while(i + count < length 
                && nums[i + count] <= threshold
                && nums[i + count] % 2 == count % 2)
                    count++;
                
                result = Math.Max(count, result);
            }

            return result;
        }
    }
}