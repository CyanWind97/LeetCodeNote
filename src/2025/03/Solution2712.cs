using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2712
/// title:  使所有字符相等的最小成本
/// problems: https://leetcode.cn/problems/minimum-cost-to-make-all-characters-equal
/// date: 20250327
/// </summary>
public static class Solution2712
{
    public static long MinimumCost(string s) {
        long cost = 0;
        int n = s.Length;
        
        for (int i = 1; i < n; i++) {
            // 如果当前字符与前一个字符不同
            if (s[i] != s[i - 1]) {
                // 取反转左侧(0~i-1)和反转右侧(i~n-1)的最小成本
                cost += Math.Min(i, n - i);
            }
        }
        
        return cost;
    }
}
