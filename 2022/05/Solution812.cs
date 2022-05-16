using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 812
    /// title:  最大三角形面积
    /// problems: https://leetcode.cn/problems/largest-triangle-area/
    /// date: 20220515
    /// </summary>
    public static class Solution812
    {
        public static double LargestTriangleArea(int[][] points) {
            int n = points.Length;
            double result = 0;
            
            double TriangleArea(int x1, int y1, int x2, int y2, int x3, int y3) 
                => 0.5 * Math.Abs(x1 * y2 + x2 * y3 + x3 * y1 - x1 * y3 - x2 * y1 - x3 * y2);
                
            for (int i = 0; i < n; i++) {
                for (int j = i + 1; j < n; j++) {
                    for (int k = j + 1; k < n; k++) {
                        result = Math.Max(result, TriangleArea(points[i][0], points[i][1], points[j][0], points[j][1], points[k][0], points[k][1]));
                    }
                }

            }
        
            return result;
        }
    }
}