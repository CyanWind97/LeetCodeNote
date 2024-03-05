using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2917
/// title: 找出数组中的 K-or 值
/// problems: https://leetcode.cn/problems/find-the-k-or-of-an-array
/// date: 20240306
/// </summary>
public static class Solution2917
{
    public static int FindKOr(int[] nums, int k) {
        var result = 0;
        for (int i = 0; i < 31; i++) {
            var count = 0;
            foreach (var x in nums) {
                if (((x >> i) & 1) == 1) 
                    count++;
            }

            if (count >= k) 
                result |= 1 << i;
        }

        return result;
    }
}
