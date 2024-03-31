using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 581
    /// title: 最短无序连续子数组
    /// problems: https://leetcode-cn.com/problems/shortest-unsorted-continuous-subarray/
    /// date: 20210803
    /// </summary>
    public static class Solution581
    {
        public static int FindUnsortedSubarray(int[] nums) {
            int length = nums.Length;
            int left = 0;
            int right = nums.Length -  1;
            var copy = new int[length];
            nums.CopyTo(copy, 0);
            Array.Sort(copy);

            while(left < length && nums[left] == copy[left]){
                left++;
            }

            while(right >= left && nums[right] == copy[right]){
                right--;
            }

            return right - left + 1;
        }


        public static int FindUnsortedSubarray_1(int[] nums){
            int length = nums.Length;
            int max = int.MinValue;
            int min = int.MaxValue;
            int right = -1;
            int left = -1;
            for (int i = 0; i < length; i++) {
                if (max > nums[i])
                    right = i;
                else
                    max = nums[i];
                
                if (min < nums[length - i - 1])
                    left = length - i - 1;
                else
                    min = nums[length - i - 1];
                
            }
            return right == -1 ? 0 : right - left + 1;

        }
    }
}