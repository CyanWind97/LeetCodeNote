using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2798
/// title: 满足目标工作时长的员工数目
/// problems: https://leetcode.cn/problems/number-of-employees-who-met-the-target
/// date: 20240430
/// </summary>
public static class Solution2798
{
    public static int NumberOfEmployeesWhoMetTarget(int[] hours, int target) {
        return hours.Count(h => h >= target);
    }
}
