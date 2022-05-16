using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{

    /// <summary>
    /// no: 152
    /// title:   乘积最大子数组
    /// problems: https://leetcode.cn/problems/maximum-product-subarray/
    /// date: 20220516
    /// priority: 0061
    /// time: 00:10:09.25 timeout
    /// </summary>   
    public static class CodeTop152
    {   
        // 参考解答 dp
        public static int MaxProduct(int[] nums) {
            int maxF = nums[0];
            int minF = nums[0];
            int result = nums[0];
            int length = nums.Length;
            
            for(int i = 1; i < length; i++){
                int mx = maxF * nums[i];
                int mn = minF * nums[i];

                maxF = Math.Max(mx, Math.Max(nums[i], mn));
                minF = Math.Min(mn, Math.Min(nums[i], mx));
                result = Math.Max(maxF, result);
            }

            return result;
        }
    }
}