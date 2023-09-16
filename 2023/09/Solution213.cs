using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 213
    /// title: 打家劫舍 II
    /// problems: https://leetcode.cn/problems/house-robber-ii/?envType=daily-question&envId=2023-09-17
    /// date: 20230917
    /// </summary>
    public static class Solution213
    {
        public static int Rob(int[] nums) {
            int length = nums.Length;
            if(length == 1)
                return  nums[0];
            
            if(length == 2)
                return  Math.Max(nums[0], nums[1]);

            int RobRange(int start, int end)
            {
                int first = nums[start];
                int second = Math.Max(nums[start], nums[start + 1]);

                for(int i = start + 2; i <= end; i++)
                {
                    int tmp = second;
                    second = Math.Max(first + nums[i], second);
                    first = tmp;
                }

                return second;
            }

            return  Math.Max(RobRange(0, length - 2), RobRange(1, length - 1));
        }
    }
}