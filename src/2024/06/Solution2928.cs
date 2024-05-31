using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2928
/// title: 给小朋友们分糖果 I
/// problems: https://leetcode.cn/problems/distribute-candies-among-children-i
/// date: 20240601
/// </summary>
public static class Solution2928
{
    public static int DistributeCandies(int n, int limit) {
        int C(int x)
            => x < 0 ? 0 : x * (x - 1) / 2;
        
         return C(n + 2) - 3 * C(n - limit + 1) + 3 * C(n - (limit + 1) * 2 + 2) - C(n - 3 * (limit + 1) + 2);
    }
}
