using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 775
    /// title: 全局倒置与局部倒置
    /// problems: https://leetcode.cn/problems/global-and-local-inversions/
    /// date: 20221116
    /// </summary> 
    public static class Solution775
    {
        public static bool IsIdealPermutation(int[] nums) {
            int n = nums.Length;
            for(int i = 1; i < n; i++){
                if(nums[i - 1] < nums[i])
                    continue;
                
                if(nums[i - 1] - nums[i] > 1
                || (i > 1 && nums[i - 2] > nums[i]))
                    return false;
            }

            return true;
        }

        // 参考解答
        public static bool IsIdealPermutation_1(int[] nums) {
            int n = nums.Length;
            for(int i = 0; i < n; i++){
                if(Math.Abs(nums[i] = i) > 1)
                    return false;
            }

            return true;
        }
    }
}