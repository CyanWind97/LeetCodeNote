using System;

namespace LeetCodeNote
{

    /// <summary>
    /// no: 1620
    /// title: 网络信号最好的坐标
    /// problems: https://leetcode.cn/problems/coordinate-with-maximum-network-quality/
    /// date: 20221102
    /// </summary>    
    public static class Solution1620
    {
        // 参考解答
        // 枚举？
        public static int[] BestCoordinate(int[][] towers, int radius) {
            int xMax = int.MinValue;
            int yMax = int.MinValue;
            int xMin = int.MaxValue;
            int yMin = int.MaxValue;

            foreach(var tower in towers){
                int x = tower[0];
                int y = tower[1];

                xMax = Math.Max(xMax, x);
                yMax = Math.Max(yMax, y);
                xMin = Math.Min(xMin, x);
                yMin = Math.Min(yMin, y);
            }

            int cx = 0, cy = 0;
            int maxQ = 0;

            int GetDistance(int x1, int y1, int x2, int y2)
                => (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);

            for(int x = xMin; x <= xMax; x++){
                for(int y = 0; y <= yMax; y++){
                    int q = 0;
                    foreach(var tower in towers) {
                        int d = GetDistance(tower[0], tower[1], x, y);
                        if(d <= radius * radius)
                            q += (int)Math.Floor(tower[2] / (1 + Math.Sqrt(d)));
                    }

                    if(q > maxQ){
                        cx = x;
                        cy = y;
                        maxQ = q;
                    }
                }
            }

            return new int[]{cx, cy};
        }
    }
}