using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3219
/// title: 切蛋糕的最小总开销 II
/// problems: https://leetcode.cn/problems/minimum-cost-for-cutting-cake-ii
/// date: 20241231
/// </summary>
public static class Solution3219
{
    public static long MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut) {
        var (rowCuts, colCuts) = (1, 1);
        long result = 0;
        Array.Sort(horizontalCut, (a, b) => b.CompareTo(a));
        Array.Sort(verticalCut, (a, b) => b.CompareTo(a));
        int i = 0, j = 0;
        while (i < horizontalCut.Length || j < verticalCut.Length) {
            if (j == verticalCut.Length || (i < horizontalCut.Length && horizontalCut[i] >= verticalCut[j])) {
                result += horizontalCut[i++] * colCuts;
                rowCuts++;
            } else {
                result += verticalCut[j++] * rowCuts;
                colCuts++;
            }
        }
        return result;
    }
}
