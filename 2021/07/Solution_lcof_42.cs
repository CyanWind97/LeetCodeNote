using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 42
    /// title: 连续子数组的最大和
    /// problems: https://leetcode-cn.com/problems/lian-xu-zi-shu-zu-de-zui-da-he-lcof/
    /// date: 20210717
    /// type: 剑指Offer lcof
    /// </summary>
    public class Solution_lcof_42
    {
        public static int MaxSubArray(int[] nums) {
            int pre = 0;
            int max = nums[0];
            foreach(var x in nums){
                pre = Math.Max(pre + x, x);
                max = Math.Max(max, pre);
            }
            
            return max; 
        }
    }
}