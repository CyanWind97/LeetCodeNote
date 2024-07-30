using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3111
/// title: 覆盖所有点的最少矩形数目
/// problems: https://leetcode.cn/problems/minimum-rectangles-to-cover-points
/// date: 20240731
/// </summary>
public static class Solution3111
{
    public static int MinRectanglesToCoverPoints(int[][] points, int w) {
        var xSet = points.Select(p => p[0])
                    .Distinct()
                    .OrderBy(x => x)
                    .ToArray();
    
        int result = 0;
        int prev = xSet[0];

        for(int i = 1; i < xSet.Length; i++){
            if (xSet[i] - prev > w) {
                result++;
                prev = xSet[i];
            }
        }

        result++;

        return result;
    }
}
