using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1673
/// title: 找出最具竞争力的子序列
/// problems: https://leetcode.cn/problems/find-the-most-competitive-subsequence
/// date: 20240524
/// </summary>
public static class Solution1673
{
    public static int[] MostCompetitive(int[] nums, int k) {
        var stack = new Stack<int>();
        int length = nums.Length;
        for (int i = 0; i < length; i++) {
            while (stack.Count > 0 && stack.Peek() > nums[i] && stack.Count + length - i > k) {
                stack.Pop();
            }
            
            stack.Push(nums[i]);
        }

        var result = new int[k];
        while (stack.Count > k) {
            stack.Pop();
        }

        for(int i = 1; i <= k; i++) {
            result[^i] = stack.Pop();
        }

        return result;
    }
}
