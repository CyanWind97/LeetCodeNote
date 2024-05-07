using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2079
/// title: 给植物浇水
/// problems: https://leetcode.cn/problems/watering-plants
/// date: 20240508
/// </summary>
public static class Solution2079
{
    public static int WateringPlants(int[] plants, int capacity) {
        int n = plants.Length;
        int result = 0;
        int water = capacity;
        for (int i = 0; i < n; i++) {
            if (water < plants[i]) {
                water = capacity;
                result += i * 2;
            }

            water -= plants[i];
            result++;
        }

        return result;
    }
}
