using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3200
/// title: 三角形的最大高度
/// problems: htthttps://leetcode.cn/problems/maximum-height-of-a-triangle
/// date: 20241015
/// </summary>
public static class Solution3200
{
    public static int MaxHeightOfTriangle(int red, int blue) {
        int MaxHeight(int x, int y) {
            int odd = 2 * (int)(Math.Sqrt(x)) - 1;
            int even = 2 * (int)((-1 + Math.Sqrt(1 + 4 * y)) / 2);
            return Math.Min(odd, even) + 1;
        }

        return Math.Max(MaxHeight(red, blue), MaxHeight(blue, red));
    }
}
