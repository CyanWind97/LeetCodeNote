using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1637
    /// title: 两点之间不包含任何点的最宽垂直区域
    /// problems: https://leetcode.cn/problems/widest-vertical-area-between-two-points-containing-no-points/
    /// date: 20230330
    /// </summary>
    public static class Solution1637
    {
        public static int MaxWidthOfVerticalArea(int[][] points) {
            Array.Sort(points, (a, b) => a[0] - b[0]);
            
            int max = 0;
            int length = points.Length;
            for(int i = 0; i < length - 1; i++){
                max = Math.Max(max, points[i + 1][0] - points[i][0]);
            }

            return max;
        }   
    }
}