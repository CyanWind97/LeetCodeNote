using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 223
    /// title: 矩形面积
    /// problems: https://leetcode-cn.com/problems/rectangle-area/
    /// date: 20210930
    /// </summary>
    public static class Solution223
    {
        public static int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2) {
            int area1 = (ax2 - ax1) * (ay2 - ay1);
            int area2 = (bx2 - bx1) * (by2 - by1);

            
            int overlapWidth = Math.Min(ax2, bx2) - Math.Max(ax1, bx1);
            int overlapHeight = Math.Min(ay2, by2) - Math.Max(ay1, by1);
            int overlapArea = Math.Max(overlapWidth, 0) * Math.Max(overlapHeight, 0);
            
            return area1 + area2 - overlapArea;
        }
    }
}