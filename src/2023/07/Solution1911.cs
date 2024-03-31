using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1911
    /// title:  最大子序列交替和
    /// problems: https://leetcode.cn/problems/maximum-alternating-subsequence-sum/
    /// date: 20230711
    /// </summary>
    public static class Solution1911
    {
        public static long MaxAlternatingSum(int[] nums) {
            int length = nums.Length;
            long odd = 0, even = nums[0];
            for (int i = 0; i < length; i++) {
                even = Math.Max(even, odd + nums[i]);
                odd = Math.Max(odd, even - nums[i]);
            }
            
            return even;
        }
    }
}