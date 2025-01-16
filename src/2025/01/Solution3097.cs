using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3097
/// title: 或值至少为 K 的最短子数组 II
/// problems: https://leetcode.cn/problems/shortest-subarray-with-or-at-least-k-ii
/// date: 20250117
/// </summary>
public static class Solution3097
{
    public static int MinimumSubarrayLength(int[] nums, int k) {
         int n = nums.Length;
        int[] bits = new int[30];
        int res = int.MaxValue;

        int Calc(int[] bits) {
            int ans = 0;
            for (int i = 0; i < bits.Length; i++) {
                if (bits[i] > 0) {
                    ans |= 1 << i;
                }
            }
            return ans;
        }

        for (int left = 0, right = 0; right < n; right++) {
            for (int i = 0; i < 30; i++) {
                bits[i] += (nums[right] >> i) & 1;
            }
            while (left <= right && Calc(bits) >= k) {
                res = Math.Min(res, right - left + 1);
                for (int i = 0; i < 30; i++) {
                    bits[i] -= (nums[left] >> i) & 1;
                }
                left++;
            }
        }

        return res == int.MaxValue ? -1 : res;
    }
}
