using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 134
/// title: 加油站
/// problems: https://leetcode.cn/problems/gas-station
/// date: 20241006
/// </summary>
public static class Solution134
{
    public static int CanCompleteCircuit(int[] gas, int[] cost) {
        int n = gas.Length;
        int totalTank = 0;
        int currTank = 0;
        int startingStation = 0;
        for (int i = 0; i < n; ++i) {
            totalTank += gas[i] - cost[i];
            currTank += gas[i] - cost[i];
            // If one couldn't get here,
            if (currTank < 0) {
                // Pick up the next station as the starting one.
                startingStation = i + 1;
                // Start with an empty tank.
                currTank = 0;
            }
        }
        return totalTank >= 0 ? startingStation : -1;
    }
}
