using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode;

/// <summary>
/// no: 3218
/// title: 切蛋糕的最小总开销 I
/// problems: https://leetcode.cn/problems/minimum-cost-for-cutting-cake-i
/// date: 20241225
/// </summary>
public static class Solution3218
{
    public static int MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut) {
        var (rowCuts, colCuts) = (1, 1);
        int ans = 0;
        Array.Sort(horizontalCut, (a, b) => b.CompareTo(a));
        Array.Sort(verticalCut, (a, b) => b.CompareTo(a));
        int i = 0, j = 0;
        while (i < horizontalCut.Length || j < verticalCut.Length) {
            if (j == verticalCut.Length || (i < horizontalCut.Length && horizontalCut[i] >= verticalCut[j])) {
                ans += horizontalCut[i++] * colCuts;
                rowCuts++;
            } else {
                ans += verticalCut[j++] * rowCuts;
                colCuts++;
            }
        }
        return ans;
    }
}
