using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1838
    /// title: 最高频元素的频数
    /// problems: https://leetcode-cn.com/problems/frequency-of-the-most-frequent-element/
    /// date: 20210719
    /// </summary>
    public static class Solution1838
    {
        // 参考解答 排序 + 滑动窗口
        public static int MaxFrequency(int[] nums, int k) {
            Array.Sort(nums);
            int n = nums.Length;
            long total = 0;
            int l = 0, res = 1;
            for (int r = 1; r < n; ++r) {
                total += (long) (nums[r] - nums[r - 1]) * (r - l);
                while (total > k) {
                    total -= nums[r] - nums[l];
                    ++l;
                }
                res = Math.Max(res, r - l + 1);
            }
            return res;
        }
    }
}