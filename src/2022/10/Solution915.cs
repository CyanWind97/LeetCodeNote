using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 915
    /// title: 分割数组
    /// problems: https://leetcode.cn/problems/partition-array-into-disjoint-intervals/
    /// date: 20221024
    /// </summary>
    public static class Solution915
    {
        public static int PartitionDisjoint(int[] nums) {
            int length = nums.Length;
            int leftMax = nums[0];
            int left = 0;
            int curMax = nums[0];
            for (int i = 1; i < length - 1; i++) {
                curMax = Math.Max(curMax, nums[i]);
                if (nums[i] < leftMax) {
                    leftMax = curMax;
                    left = i;
                }
            }

            return left + 1;
        }
    }
}