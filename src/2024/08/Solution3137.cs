using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3137
/// title: K 周期字符串需要的最少操作次数
/// problems: https://leetcode.cn/problems/minimum-number-of-operations-to-make-word-k-periodic
/// date: 20240817
/// </summary>
public static class Solution3137
{
    public static int MinimumOperationsToMakeKPeriodic(string word, int k) {
        int n = word.Length;
        int result = int.MaxValue;
        var count = new Dictionary<string, int>();

        for (int i = 0; i < n; i+=k) {
            var part = word.Substring(i, k);
            count.TryAdd(part, 0);
            count[part]++;

            result = Math.Min(result, n / k - count[part]);
        }

        return result;
    }
}
