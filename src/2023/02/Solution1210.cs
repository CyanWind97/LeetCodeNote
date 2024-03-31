using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1210
    /// title: 穿过迷宫的最少移动次数
    /// problems: https://leetcode.cn/problems/minimum-moves-to-reach-target-with-rotations/
    /// date: 20230205
    /// </summary>
    public static class Solution1210
    {
        // 参考解答
        // 广度优先
        public static int MinimumMoves(int[][] grid) {
            int n = grid.Length;
            var dist = new int[n, n, 2];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    dist[i, j, 0] = dist[i, j, 1] = -1;
                }
            }

            dist[0, 0, 0] = 0;
            var queue = new Queue<(int X, int Y, int Status)>();
            queue.Enqueue((0, 0, 0));

            while (queue.Count > 0) {
                (int x, int y, int status) = queue.Dequeue();
                if (status == 0) {
                    // 向右移动一个单元格
                    if (y + 2 < n && dist[x, y + 1, 0] == -1 && grid[x][y + 2] == 0) {
                        dist[x, y + 1, 0] = dist[x, y, 0] + 1;
                        queue.Enqueue((x, y + 1, 0));
                    }
                    // 向下移动一个单元格
                    if (x + 1 < n && dist[x + 1, y, 0] == -1 && grid[x + 1][y] == 0 && grid[x + 1][y + 1] == 0) {
                        dist[x + 1, y, 0] = dist[x, y, 0] + 1;
                        queue.Enqueue((x + 1, y, 0));
                    }
                    // 顺时针旋转 90 度
                    if (x + 1 < n && y + 1 < n && dist[x, y, 1] == -1 && grid[x + 1][y] == 0 && grid[x + 1][y + 1] == 0) {
                        dist[x, y, 1] = dist[x, y, 0] + 1;
                        queue.Enqueue((x, y, 1));
                    }
                } else {
                    // 向右移动一个单元格
                    if (y + 1 < n && dist[x, y + 1, 1] == -1 && grid[x][y + 1] == 0 && grid[x + 1][y + 1] == 0) {
                        dist[x, y + 1, 1] = dist[x, y, 1] + 1;
                        queue.Enqueue((x, y + 1, 1));
                    }
                    // 向下移动一个单元格
                    if (x + 2 < n && dist[x + 1, y, 1] == -1 && grid[x + 2][y] == 0) {
                        dist[x + 1, y, 1] = dist[x, y, 1] + 1;
                        queue.Enqueue((x + 1, y, 1));
                    }
                    // 逆时针旋转 90 度
                    if (x + 1 < n && y + 1 < n && dist[x, y, 0] == -1 && grid[x][y + 1] == 0 && grid[x + 1][y + 1] == 0) {
                        dist[x, y, 0] = dist[x, y, 1] + 1;
                        queue.Enqueue((x, y, 0));
                    }
                }
            }

            return dist[n - 1, n - 2, 0];
        }
    }
}