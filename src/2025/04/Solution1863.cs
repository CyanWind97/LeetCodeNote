using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1863
/// title: 找出所有子集的异或总和再求和
/// problems: https://leetcode.cn/problems/sum-of-all-subset-xor-totals
/// date: 20250405
/// </summary>
public static class Solution1863
{
    public static int SubsetXORSum(int[] nums) {
        int res = 0;
        int n = nums.Length;
        foreach (int num in nums) {
            res |= num;
        }
        return res << (n - 1);
    }
}
