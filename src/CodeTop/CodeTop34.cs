using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 34
    /// title:  在排序数组中查找元素的第一个和最后一个位置
    /// problems: https://leetcode.cn/problems/find-first-and-last-position-of-element-in-sorted-array/
    /// date: 20220515
    /// priority: 0054
    /// time: 00:02:38.71
    /// </summary>
    public static class CodeTop34
    {
        public static int[] SearchRange(int[] nums, int target) {
            var index = Array.BinarySearch(nums, target);
            if(index < 0)
                return new int[]{-1, -1};
            
            int length = nums.Length;
            int left = index;
            int right = index;
            
            while(left > 0 && nums[left] == nums[left - 1]){
                left--;
            }

            while(right < length - 1 && nums[right] == nums[right + 1]){
                right++;
            }

            return new int[]{left, right};
        }
    }
}