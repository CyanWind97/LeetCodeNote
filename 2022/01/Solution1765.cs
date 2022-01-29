using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1765
    /// title: 图中的最高点
    /// problems: hhttps://leetcode-cn.com/problems/map-of-highest-peak/
    /// date: 20220129
    /// </summary>
    public static class Solution1765
    {
        public static int[][] HighestPeak(int[][] isWater) {
            var m = isWater.Length;
            var n = isWater[0].Length;
            var result = new int[m][];
            for (int i = 0; i < m; ++i) {
                result[i] = new int[n];
                Array.Fill(result[i], -1); // -1 表示该格子尚未被访问过
            }
            var queue = new Queue<(int X, int Y)>();
            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n; ++j) {
                    if (isWater[i][j] == 1) {
                        result[i][j] = 0;
                        queue.Enqueue((i, j)); // 将所有水域入队
                    }
                }
            }

            IEnumerable<(int X, int Y)> GetPoint((int X, int Y) point)
            {
                if( point.X > 0 && result[point.X - 1][point.Y] == -1)
                    yield return (point.X - 1, point.Y);

                if( point.X < m - 1 && result[point.X + 1][point.Y] == -1)
                    yield return (point.X + 1, point.Y);
                
                if( point.Y > 0 && result[point.X][point.Y - 1] == -1)
                    yield return (point.X, point.Y - 1);
                
                if( point.Y < n - 1 && result[point.X][point.Y + 1] == -1)
                    yield return (point.X , point.Y + 1);
            }

            while (queue.Count > 0) {
                var cur = queue.Dequeue();
                foreach (var point in GetPoint(cur)) {
                    result[point.X][point.Y] = result[cur.X][cur.Y] + 1;
                    queue.Enqueue(point);
                }
            }

            return result;
        }
    }
}