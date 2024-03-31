using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 154
    /// title: 寻找旋转排序数组中的最小值 II
    /// problems: https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array-ii/
    /// date: 20210409
    /// </summary>
    public static class Solution154
    {
        public static int FindMin(int[] nums) {
            int length = nums.Length;
            int left = 0;
            int right = length - 1;

            while(left < right)
            {
                int mid = left + ((right - left) >> 1);
                if(nums[mid] < nums[right])
                    right = mid;
                else if(nums[mid] > nums[right])
                    left = mid + 1;
                else
                    right--;
            }

            return nums[left];
        }
    }
}