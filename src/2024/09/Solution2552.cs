using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2552
/// title:  统计上升四元组
/// problems: https://leetcode.cn/problems/count-increasing-quadruplets
/// date: 20240910
/// </summary>
public static class Solution2552
{
    public static long CountQuadruplets(int[] nums) {
        int n = nums.Length;
        int[] pre = new int[n + 1];
        long ans = 0;
        for (int j = 0; j < n; ++j) {
            int suf = 0;
            for (int k = n - 1; k > j; --k) {
                if (nums[j] > nums[k]) {
                    ans += (long) pre[nums[k]] * suf;
                } else {
                    ++suf;
                }
            }
            for (int x = nums[j] + 1; x <= n; ++x) {
                ++pre[x];
            }
        }
        return ans;
    }
}
