using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2275
/// title: 求出数字答案
/// problems: https://leetcode.cn/problems/find-the-key-of-the-numbers
/// date: 20250112
/// </summary>
public static class Solution2275
{
    public static int LargestCombination(int[] candidates) {
        int result = 0;

        for (int i = 0; i < 24; i++) {
            int count = 0;
            foreach (int candidate in candidates) {
               count += (candidate >> i) & 1;
            }

            result = Math.Max(result, count);
        }
        
        return result;
    }
}
