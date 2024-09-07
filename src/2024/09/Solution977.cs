using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 977
/// title:  序数组的平方
/// problems: https://leetcode.cn/problems/squares-of-a-sorted-array
/// date: 20240908
/// </summary>
public static class Solution977
{
    public static int[] SortedSquares(int[] nums) {
        var result = nums.Select(x => x * x).ToArray();
        Array.Sort(result);
        return result;
    }
}
