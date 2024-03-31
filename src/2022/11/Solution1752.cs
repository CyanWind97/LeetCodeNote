using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1752
    /// title: 检查数组是否经排序和轮转得到
    /// problems: https://leetcode.cn/problems/check-if-array-is-sorted-and-rotated/
    /// date: 20221127
    /// </summary>
    public static class Solution1752
    {
        public static bool Check(int[] nums) {
            int length = nums.Length; 
            int x = 0;
            for(int i = 1; i < length; i++){
                if(nums[i] < nums[i - 1]){
                    x = i;
                    break;
                }
            }

            if(x == 0)
                return true;
            
            for(int i = x + 1; i < length; i++){
                if(nums[i] < nums[i - 1])
                    return false;
            }

            return nums[0] >= nums[length - 1];
        }
    }
}