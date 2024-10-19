using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 908
    /// title: 最小差值 I
    /// problems: https://leetcode-cn.com/problems/smallest-range-i/
    /// date: 20220430
    /// </summary>
    public static partial class Solution908
    {
        public static int SmallestRangeI(int[] nums, int k) {
            int length = nums.Length;
            int min = 10001;
            int max = -1;

            foreach(var num in nums){
                min = Math.Min(num, min);
                max = Math.Max(num, max);
            }


            return max - min > 2 * k  ? max - min - 2 * k : 0;
        }
    }
}