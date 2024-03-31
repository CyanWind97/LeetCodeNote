using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 930
    /// title: 和相同的二元子数组
    /// problems: https://leetcode-cn.com/problems/binary-subarrays-with-sum/
    /// date: 20210708
    /// </summary>
    public static class Solution930
    {
        public static int NumSubarraysWithSum(int[] nums, int goal) {
            int n = nums.Length;
            int left1 = 0, left2 = 0, right = 0;
            int sum1 = 0, sum2 = 0;
            int result = 0;
            while (right < n) {
                sum1 += nums[right];
                while (left1 <= right && sum1 > goal) {
                    sum1 -= nums[left1];
                    left1++;
                }
                sum2 += nums[right];
                while (left2 <= right && sum2 >= goal) {
                    sum2 -= nums[left2];
                    left2++;
                }
                result += left2 - left1;
                right++;
            }
            return result;
        }
    }
}