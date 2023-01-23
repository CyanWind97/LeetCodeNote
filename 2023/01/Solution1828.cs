using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1828
    /// title: 统计一个圆中点的数目
    /// problems: https://leetcode.cn/problems/queries-on-number-of-points-inside-a-circle/
    /// date: 20230124
    /// </summary>
    public static class Solution1828
    {
        public static int[] CountPoints(int[][] points, int[][] queries) {

            bool IsInCircle(int x, int y, int cx, int cy, int cr)
                => (x - cx) * (x - cx) + (y - cy) * (y - cy) <= cr * cr;
            
            return queries.Select(query => points.Count(point => IsInCircle(point[0], point[1], query[0], query[1], query[2])))
                          .ToArray();
        }
    }
}