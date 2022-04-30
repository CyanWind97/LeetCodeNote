using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 905
    /// title: 按奇偶排序数组
    /// problems: https://leetcode-cn.com/problems/sort-array-by-parity/
    /// date: 20220428
    /// </summary>
    public static class Solution905
    {
        public static int[] SortArrayByParity(int[] nums) {
            Array.Sort(nums, (a, b) => a % 2 - b % 2);

            return nums;
        }
    }
}