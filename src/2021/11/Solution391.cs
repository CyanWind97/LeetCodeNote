using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 301
    /// title:  完美矩形
    /// problems: https://leetcode-cn.com/problems/perfect-rectangle/
    /// date: 20211116
    /// </summary>
    public static class Solution391
    {
        // 参考解答 哈希 按点相邻矩形数判断是否完整
        public static bool IsRectangleCover(int[][] rectangles) {
            long area = 0;
            int minX = rectangles[0][0], minY = rectangles[0][1], maxX = rectangles[0][2], maxY = rectangles[0][3];
            var cnt = new Dictionary<(int X, int Y), int>();
            
            void AddPoint(int x, int y){
                var point = (x, y);
                if (!cnt.ContainsKey(point))
                    cnt.Add(point, 0);
                
                cnt[point]++;
            }

            foreach (int[] rect in rectangles) {
                int x = rect[0], y = rect[1], a = rect[2], b = rect[3];
                area += (long) (a - x) * (b - y);

                minX = Math.Min(minX, x);
                minY = Math.Min(minY, y);
                maxX = Math.Max(maxX, a);
                maxY = Math.Max(maxY, b);

                AddPoint(x, y);
                AddPoint(x, b);
                AddPoint(a, y);
                AddPoint(a, b);
            }

            var pointMinMin =  (minX, minY);
            var pointMinMax =  (minX, maxY);
            var pointMaxMin =  (maxX, minY);
            var pointMaxMax =  (maxX, maxY);

            if (area != (long) (maxX - minX) * (maxY - minY) 
                || !cnt.ContainsKey(pointMinMin) 
                || cnt[pointMinMin] != 1 
                || !cnt.ContainsKey(pointMinMax) 
                || cnt[pointMinMax] != 1 
                || !cnt.ContainsKey(pointMaxMin) 
                || cnt[pointMaxMin] != 1 
                || !cnt.ContainsKey(pointMaxMax) 
                || cnt[pointMaxMax] != 1) 
                return false;
            

            cnt.Remove(pointMinMin);
            cnt.Remove(pointMinMax);
            cnt.Remove(pointMaxMin);
            cnt.Remove(pointMaxMax);

            foreach (var entry in cnt) {
                int value = entry.Value;
                if (value != 2 && value != 4)
                    return false;
            }

            return true;
        }
    }
    
}