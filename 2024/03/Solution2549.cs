using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2549
/// title: 统计桌面上的不同数字
/// problems: https://leetcode.cn/problems/count-distinct-numbers-on-board
/// date: 20240323
/// </summary>
public static class Solution2549
{
    public static int DistinctIntegers(int n) {
        return n == 1 ? 1 : n - 1;
    }
}
