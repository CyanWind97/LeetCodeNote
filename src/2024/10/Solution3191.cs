using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3191
/// title: 使二进制数组全部等于 1 的最少操作次数 I
/// problems: https://leetcode.cn/problems/minimum-operations-to-make-binary-array-elements-equal-to-one-i
/// date: 20241018
/// </summary>
public static class Solution3191
{
    public static int MinOperations(int[] nums) {
        int n = nums.Length;
        int operations = 0;

        for (int i = 0; i <= n - 3; i++) {
            if (nums[i] == 0) {
                operations++;
                nums[i] = 1;
                nums[i + 1] = nums[i + 1] == 0 ? 1 : 0;
                nums[i + 2] = nums[i + 2] == 0 ? 1 : 0;
            }
        }

        for (int i = n - 3; i < n; i++) {
            if (nums[i] == 0) {
                return -1;
            }
        }

        return operations;
    }
}
