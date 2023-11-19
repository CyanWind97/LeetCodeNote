using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 53
    /// title:  最大子数组和
    /// problems: https://leetcode.cn/problems/maximum-subarray/description/?envType=daily-question&envId=2023-11-20
    /// date: 20231120
    /// </summary>
    public static class Solution53
    {
        public static int MaxSubArray(int[] nums) {
            int result = -10001;
            int sum = 0;
            foreach(var num in nums){
                sum = Math.Max(num, num + sum);
                result = Math.Max(sum, result);
            }

            return result;
        }
    }
}