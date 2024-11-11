using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3258
/// title: 统计满足 K 约束的子字符串数量 I
/// problems: https://leetcode.cn/problems/count-substrings-that-satisfy-k-constraint-i
/// date: 20241112
/// </summary>
public static class Solution3258
{
    public static int CountKConstraintSubstrings(string s, int k) {
        int n = s.Length, res = 0;
        for (int i = 0; i < n; ++i) {
            int[] count = new int[2];
            for (int j = i; j < n; ++j) {
                count[s[j] - '0']++;
                if (count[0] > k && count[1] > k) {
                    break;
                }
                res++;
            }
        }
        
        return res;
    }
}
