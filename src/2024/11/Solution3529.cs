using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3529
/// title: 超级饮料的最大强化能量
/// problems: https://leetcode.cn/problems/maximum-energy-boost-from-two-drinks
/// date: 20241101
/// </summary>
public static class Solution3529
{
    public static long MaxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB) {
        int n = energyDrinkA.Length;
        var dpA = new long[n];
        var dpB = new long[n];

        dpA[0] = energyDrinkA[0];
        dpA[1] = dpA[0] + energyDrinkA[1];
        dpB[0] = energyDrinkB[0];
        dpB[1] = dpB[0] + energyDrinkB[1];

        for (int i = 2; i < n; i++) {
            dpA[i] = Math.Max(dpB[i - 2], dpA[i - 1]) + energyDrinkA[i];
            dpB[i] = Math.Max(dpA[i - 2], dpB[i - 1]) + energyDrinkB[i];
        }

        return Math.Max(dpA[n - 1], dpB[n - 1]);
    }
}
