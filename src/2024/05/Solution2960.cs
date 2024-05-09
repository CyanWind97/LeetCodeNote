using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2960
/// title: 统计已测试设备
/// problems: https://leetcode.cn/problems/count-tested-devices-after-test-operations
/// date: 20240510
/// </summary>
public static class Solution2960
{
    public static int CountTestedDevices(int[] batteryPercentages) {
        int time = 0;
        return batteryPercentages.Count(percentage => (percentage > time) && ++time > 0);
    }
}
