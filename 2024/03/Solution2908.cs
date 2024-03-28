using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2908
/// title: 元素和最小的山形三元组 I
/// problems: https://leetcode.cn/problems/minimum-sum-of-mountain-triplets-i
/// date: 20240329
/// </summary>
public static class Solution2908
{
    public static int MinimumSum(int[] nums) {
        int length = nums.Length;
        var left = new Stack<int>();
        left.Push(0);

        for (int i = 1; i < length - 1; i++) {
            if (nums[i] < nums[left.Peek()])
                left.Push(i);
        }
        
        int result = int.MaxValue;
        var right = nums[^1];
        for (int i = 2; i < length; i++){
            if (left.Peek() == length - i)
                left.Pop();

            if (nums[left.Peek()] < nums[^i] && nums[^i] > right)
                result = Math.Min(result, nums[left.Peek()] + nums[^i] + right);
            
            right = Math.Min(right, nums[^i]);
        }

        return result == int.MaxValue ? -1 : result;
    }
}
