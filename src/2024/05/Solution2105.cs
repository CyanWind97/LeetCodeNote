using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1463
/// title: 摘樱桃 II
/// problems: https://leetcode.cn/problems/cherry-pickup-ii
/// date: 20240509
/// </summary>

public static class Solution2105
{
    public static int MinimumRefill(int[] plants, int capacityA, int capacityB) {
        int n = plants.Length;
        int result = 0;
        (int posA, int posB) = (0, n - 1);
        (int waterA, int waterB) = (capacityA, capacityB);

        int WaterPlants(ref int pos, int water, int capacity, int increment = 1) {
            if (water < plants[pos]) {
                water = capacity - plants[pos];
                result++;
            } else {
                water -= plants[pos];
            }

            pos += increment;

            return water;
        }

        while (posA < posB) {
            waterA = WaterPlants(ref posA, waterA, capacityA, 1);
            waterB = WaterPlants(ref posB, waterB, capacityB,  -1);

        }

        if (posA == posB) {
            if (waterA < plants[posB] && waterB < plants[posA])
                result++;
        }

        return result;
    }
}
