using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2769
/// title: 找出最大的可达成数字
/// problems: https://leetcode.cn/problems/find-the-maximum-achievable-number
/// date: 20240521
/// </summary>
public static class Solution2769
{
    public static int TheMaximumAchievableX(int num, int t) {
        return num + 2 * t;
    }
}
