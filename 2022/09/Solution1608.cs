using System;

namespace LeetCodeNote
{
    // <summary>
    /// no: 1608
    /// title: 特殊数组的特征值
    /// problems: https://leetcode.cn/problems/special-array-with-x-elements-greater-than-or-equal-x/
    /// date: 20220912
    /// </summary>
    public static class Solution1608
    {
        public static int SpecialArray(int[] nums) {
            int length = nums.Length;
            Array.Sort(nums);
            
            for(int i = 0; i < length; i++){
                if(i != 0 && nums[i] == nums[i - 1])
                    continue;
                
                int x = length - i;
                if(i != 0 && x <= nums[i])
                    continue;

                if(x < nums[i])
                    return x;
            }

            return -1;
        }
    }
}