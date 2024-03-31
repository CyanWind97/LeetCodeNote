using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1091
    /// title: 二进制矩阵中的最短路径
    /// problems: https://leetcode.cn/problems/shortest-path-in-binary-matrix/
    /// date: 20230526
    /// </summary>
    public static class Solution1091
    {
        public static int ShortestPathBinaryMatrix(int[][] grid) {
            int n = grid.Length;
            if(grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
                return -1;
            
            var direction = new (int X, int Y)[8]
            {
                (1, 0), (1, 1), (0, 1), (-1, 1),
                (-1, 0), (-1, -1), (0, -1), (1, -1)
            };

            var dist = new int[n, n];
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    dist[i, j] = int.MaxValue;
                }
            }

            var queue = new Queue<(int X, int Y)>();
            queue.Enqueue((0, 0));
            dist[0, 0] = 1;
            while(queue.Count > 0){
                (int x, int y) = queue.Dequeue();
                if (x == n-1 && y == n-1)
                    return dist[x, y];

                foreach(var dir in direction){
                    (int nextX, int nextY) = (x + dir.X, y + dir.Y);
                    if(nextX < 0 || nextX >= n || nextY < 0 || nextY >= n)
                        continue;
                    
                    if(grid[nextX][nextY] == 1 || dist[nextX, nextY] <= dist[x, y] + 1)
                        continue;

                    dist[nextX, nextY] = dist[x, y] + 1;
                    queue.Enqueue((nextX, nextY));
                }
            }

            return -1;
        }   
    }
}