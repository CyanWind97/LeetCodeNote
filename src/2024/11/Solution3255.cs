using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3255
/// title: 长度为 K 的子数组的能量值 II
/// problems: https://leetcode.cn/problems/find-the-power-of-k-size-subarrays-ii
/// date: 20241107
/// </summary>
public static class Solution3255
{
    public static int[] ResultsArray(int[] nums, int k) {
        int n = nums.Length;
        int[] result = new int[n - k + 1];
        Array.Fill(result, -1);
        
        int count = 0;

        for (int i = 0; i < n; i++) {
            count = (i == 0 || nums[i] - nums[i - 1] != 1) ? 1 : count + 1;
            if (count >= k)
                result[i - k + 1] = nums[i];
        }

        return result;
    }
}
