using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1401
    /// title: 圆和矩形是否有重叠
    /// problems: https://leetcode.cn/problems/circle-and-rectangle-overlapping/
    /// date: 20230625
    /// </summary>
    public static class Solution1401
    {
        public static bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2) {
            var dist = 0.0;
            if (xCenter < x1 || xCenter > x2)
                dist += Math.Min(Math.Pow(xCenter - x1, 2), Math.Pow(xCenter - x2, 2));
            
            if (yCenter < y1 || yCenter > y2)
                dist += Math.Min(Math.Pow(yCenter - y1, 2), Math.Pow(yCenter - y2, 2));
            
            return dist <= Math.Pow(radius, 2);
        }
    }
}