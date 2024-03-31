using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1671
    /// title: 得到山形数组的最少删除次数
    /// problems: https://leetcode.cn/problems/minimum-number-of-removals-to-make-mountain-array/description/?envType=daily-question&envId=2023-12-22
    /// date: 20231222
    /// </summary>
    public static class Solution1671
    {
        public static int MinimumMountainRemovals(int[] nums) {
            int length = nums.Length;
            int[] left = new int[length];
            int[] right = new int[length];
            Array.Fill(left, 1);
            Array.Fill(right, 1);

            for(int i = 1; i < length; i++){
                for(int j = 0; j < i; j++){
                    if(nums[i] > nums[j])
                        left[i] = Math.Max(left[i], left[j] + 1);
                }
            }

            for(int i = length - 2; i >= 0; i--){
                for(int j = length - 1; j > i; j--){
                    if(nums[i] > nums[j])
                        right[i] = Math.Max(right[i], right[j] + 1);
                }
            }

            int result = length;
            for(int i = 0; i < length; i++){
                if(left[i] > 1 && right[i] > 1)
                    result = Math.Min(result, length - (left[i] + right[i] - 1));
            }

            return result;
        }
    }
}