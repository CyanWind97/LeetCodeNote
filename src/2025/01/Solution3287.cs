using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 3287
/// title: 求出数组中最大序列值
/// problems: https://leetcode.cn/problems/find-the-maximum-sequence-value-of-array
/// date: 20250118
/// </summary>
public static class Solution3287
{
    // 参考解答
    public static int MaxValue(int[] nums, int k) {
        List<HashSet<int>> FindORs() {
            var dp = new List<HashSet<int>>();
            var prev = new List<HashSet<int>>();
            for (int i = 0; i <= k; i++) {
                prev.Add([]);
            }
            prev[0].Add(0);
            for (int i = 0; i < nums.Length; i++) {
                for (int j = Math.Min(k - 1, i + 1); j >= 0; j--) {
                    foreach (int x in prev[j]) {
                        prev[j + 1].Add(x | nums[i]);
                    }
                }
                dp.Add([.. prev[k]]);
            }
            return dp;
        }

        var A = FindORs();
        Array.Reverse(nums);
        var B = FindORs();
        int mx = 0;
        for (int i = k - 1; i < nums.Length - k; i++) {
            foreach (int a in A[i]) {
                foreach (int b in B[nums.Length - i - 2]) {
                    mx = Math.Max(mx, a ^ b);
                }
            }
        }
        return mx;
    }
}
