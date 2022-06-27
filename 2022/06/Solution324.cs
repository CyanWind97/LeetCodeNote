using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 324
    /// title: 摆动排序 II
    /// problems: https://leetcode.cn/problems/wiggle-sort-ii/
    /// date: 20220628
    /// </summary>
    public static class Solution324
    {
        public static void WiggleSort(int[] nums) {
            int length = nums.Length;
            int[] arr = new int[length];
            Array.Copy(nums, arr, length);
            Array.Sort(arr);
            int x = (length + 1) / 2;
            for (int i = 0, j = x - 1, k = length - 1; i < length; i += 2, j--, k--) {
                nums[i] = arr[j];
                if (i + 1 < length)
                    nums[i + 1] = arr[k];
            }
        }
    }
}