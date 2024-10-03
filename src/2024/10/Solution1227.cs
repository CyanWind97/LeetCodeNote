using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1928
/// title: 规定时间内到达终点的最小花费
/// problems: https://leetcode.cn/problems/airplane-seat-assignment-probability
/// date: 20241004
/// </summary>
public static class Solution1227
{
    public static double NthPersonGetsNthSeat(int n) {
        return n == 1 ? 1 : 0.5;
    }
}
