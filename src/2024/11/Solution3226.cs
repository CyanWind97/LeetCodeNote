using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3226
/// title: 使两个整数相等的位更改次数
/// problems: https://leetcode.cn/problems/number-of-bit-changes-to-make-two-integers-equal
/// date: 20241102
/// </summary>
public static class Solution3226
{
    public static int MinChanges(int n, int k) {
        return (n & k) == k
            ? int.PopCount(n ^ k)
            : -1;
    }
}
