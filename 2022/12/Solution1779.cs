using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1779
    /// title:  找到最近的有相同 X 或 Y 坐标的点
    /// problems: https://leetcode.cn/problems/find-nearest-point-that-has-the-same-x-or-y-coordinate/
    /// date: 20221201
    /// </summary>
    public static class Solution1779
    {
        public static int NearestValidPoint(int x, int y, int[][] points) {
            int n = points.Length;
            int best = int.MaxValue;
            int bestid = -1;

            for (int i = 0; i < n; ++i) {
                int px = points[i][0], py = points[i][1];
                if (x == px) {
                    int dist = Math.Abs(y - py);
                    if (dist >= best)
                        continue;
                    
                    best = dist;
                    bestid = i;
                    
                } else if (y == py) {
                    int dist = Math.Abs(x - px);
                    if (dist >= best) 
                        continue;

                        best = dist;
                        bestid = i;
                }
            }

            return bestid;
        }
    }
}