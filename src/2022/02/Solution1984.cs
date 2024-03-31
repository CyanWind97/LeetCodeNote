using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1984
    /// title: 学生分数的最小差值
    /// problems: https://leetcode-cn.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores/
    /// date: 20220211
    /// </summary>
    public static class Solution1984
    {
        public static int MinimumDifference(int[] nums, int k) {
            if(k == 1)
                return 0;

            int length = nums.Length;
            Array.Sort(nums);
            int min = int.MaxValue;
            for(int i = 0; i <= length - k; i++){
                min = Math.Min(min, nums[i + k - 1] - nums[i]);
            }

            return min;
        }
    }
}