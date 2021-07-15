using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1846
    /// title: 减小和重新排列数组后的最大元素
    /// problems: https://leetcode-cn.com/problems/maximum-element-after-decreasing-and-rearranging/
    /// date: 20210715
    /// </summary>
    public static class Solution1846
    {
        public static int MaximumElementAfterDecrementingAndRearranging(int[] arr) {
            int length = arr.Length;
            Array.Sort(arr);
            arr[0] = 1;
            int max = arr[0];
            for(int i = 1; i < length; i++)
            {
                if(Math.Abs(arr[i] - arr[i - 1]) > 1)
                    arr[i] = arr[i - 1] + 1;
                
                max = Math.Max(arr[i], max);
            }

            return max;
        }
    }
}