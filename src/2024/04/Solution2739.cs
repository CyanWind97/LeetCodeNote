using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 2739
/// title:  总行驶距离
/// problems: https://leetcode.cn/problems/total-distance-traveled
/// date: 20240425
/// </summary>
public static class Solution2739
{
    public static int DistanceTraveled(int mainTank, int additionalTank) {
        return 10 * (mainTank + Math.Min((mainTank - 1) / 4, additionalTank));
    }
}
