using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1254
    /// title: 统计封闭岛屿的数目
    /// problems: https://leetcode.cn/problems/number-of-closed-islands/
    /// date: 20230618
    /// </summary>
    public static class Solution1254
    {
        public static int ClosedIsland(int[][] grid) {
            int m = grid.Length;
            int n = grid[0].Length;
            int result = 0;

            var dirs = new (int X, int Y)[]{ (0, 1), (1, 0), (0, -1), (-1, 0)};
            var visited = new bool[m, n];

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    if (visited[i, j] || grid[i][j] == 1)
                        continue;
                    
                    var queue = new Queue<(int X, int Y)>();
                    bool isClosed = true;
                    queue.Enqueue((i, j));
                    visited[i, j] = true;
                    while(queue.Count > 0){
                        var (x, y) = queue.Dequeue();
                        if (isClosed ||  x == 0 || x == m - 1 || y == 0 || y == n - 1)
                            isClosed = false;

                        foreach(var (dirX, dirY) in dirs){
                            int newX = x + dirX;
                            int newY = y + dirY;
                            if(newX >= 0 && newX < m && newY >= 0 && newY < n 
                            && !visited[newX, newY] && grid[newX][newY] == 0){
                                queue.Enqueue((newX, newY));
                                visited[newX, newY] = true;
                            }
                        }
                    }

                    if (isClosed)
                        result++;
                }
            }

            return result;
        }
    }
}