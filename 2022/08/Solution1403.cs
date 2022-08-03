using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1403
    /// title:  非递增顺序的最小子序列
    /// problems: https://leetcode.cn/problems/minimum-subsequence-in-non-increasing-order/
    /// date: 20220804
    /// </summary>
    public static class Solution1403
    {
        public static IList<int> MinSubsequence(int[] nums) {
            int total = nums.Sum();
            Array.Sort(nums);
            var ans = new List<int>();
            int curr = 0;
            for (int i = nums.Length - 1; i >= 0; --i) {
                curr += nums[i];
                ans.Add(nums[i]);
                if (total - curr < curr) {
                    break;
                }
            }
            return ans;
        }
    }
}