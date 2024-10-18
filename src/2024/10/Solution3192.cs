using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3192
/// title: 使二进制数组全部等于 1 的最少操作次数 II
/// problems: https://leetcode.cn/problems/minimum-operations-to-make-binary-array-elements-equal-to-one-ii
/// date: 20241019
/// </summary>
public static class Solution3192
{
    public static int MinOperations(int[] nums) {
        int n = nums.Length;
        int operations = 0;
        bool flipped = false;

        for (int i = 0; i < n; i++) {
            if ((nums[i] == 0 && !flipped) || (nums[i] == 1 && flipped)) {
                operations++;
                flipped = !flipped;
            }
        }

        return operations;
    }
}
