using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 801
    /// title: 使序列递增的最小交换次数
    /// problems: https://leetcode.cn/problems/minimum-swaps-to-make-sequences-increasing/
    /// date: 20221010
    /// </summary>
    public static class Solution801
    {
        // 参考解答
        // 动态规划
        public static int MinSwap(int[] nums1, int[] nums2) {
            int n = nums1.Length;
            int a = 0, b = 1;
            for (int i = 1; i < n; i++) {
                int at = a, bt = b;
                a = b = n;
                if (nums1[i] > nums1[i - 1] && nums2[i] > nums2[i - 1])  {
                    a = Math.Min(a, at);
                    b = Math.Min(b, bt + 1);
                }
                if (nums1[i] > nums2[i - 1] && nums2[i] > nums1[i - 1]) {
                    a = Math.Min(a, bt);
                    b = Math.Min(b, at + 1);
                }
            }

            return Math.Min(a, b);
        }
    }
}