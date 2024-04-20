using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 216
/// title: 组合总和 III
/// problems: https://leetcode.cn/problems/combination-sum-iii
/// date: 20240421
/// </summary>
public static class Solution216
{
    public static IList<IList<int>> CombinationSum3(int k, int n) {
        List<IList<int>> result = new List<IList<int>>();
        List<int> path = new List<int>();
        void Backtrack(int target, int start) {
            if (target == 0 && path.Count == k) {
                result.Add(new List<int>(path));
                return;
            }
            if (target < 0 || path.Count == k) {
                return;
            }
            for (int i = start; i <= 9; i++) {
                path.Add(i);
                Backtrack(target - i, i + 1);
                path.RemoveAt(path.Count - 1);
            }
        }
        Backtrack(n, 1);
        return result;
    }
}
