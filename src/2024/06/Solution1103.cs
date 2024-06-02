using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1103
/// title: 分糖果 II
/// problems: https://leetcode.cn/problems/distribute-candies-to-people
/// date: 20240603
/// </summary>
public static class Solution1103
{
    // 参考解答
    public static int[] DistributeCandies(int candies, int num_people) {
        int n = num_people;
        int p = (int) (Math.Sqrt(2 * candies + 0.25) - 0.5);
        int remaining = candies - (p + 1) * p / 2;
        int rows = p / n, cols = p % n;

        int[] d = new int[n];
        for (int i = 0; i < n; ++i) {
            d[i] = (i + 1) * rows + (int) (rows * (rows - 1) * 0.5) * n;
            if (i < cols) {
                d[i] += i + 1 + rows * n;
            }
        }

        d[cols] += remaining;
        return d;
    }
}
