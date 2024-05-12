using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 994
/// title: 腐烂的橘子
/// problems: https://leetcode.cn/problems/rotting-oranges
/// date: 20240513
/// </summary>
public static class Solution994
{
    public static int OrangesRotting(int[][] grid) {
        (int m, int n) = (grid.Length, grid[0].Length);
        var visited = new bool[m, n];
        var fresh = new HashSet<(int X, int Y)>();
        var queue = new Queue<(int X, int Y, int Time)>();
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == 2){
                    queue.Enqueue((i, j, 0));
                    visited[i, j] = true;
                }else if(grid[i][j] == 1){
                    fresh.Add((i, j));
                }
            }
        }

        int result = 0;
        while(queue.Count > 0){
            var (x, y, time) = queue.Dequeue();
            result = Math.Max(result, time);
            if (grid[x][y] == 1)
                fresh.Remove((x, y));

            if(fresh.Count == 0)
                break;

            void Add(int x, int y){
                if(x >= 0 && x < m 
                && y >= 0 && y < n 
                && !visited[x, y] && grid[x][y] == 1){
                    visited[x, y] = true;
                    queue.Enqueue((x, y, time + 1));
                }
            }

            Add(x - 1, y);
            Add(x + 1, y);
            Add(x, y - 1);
            Add(x, y + 1);
        }

        return fresh.Count == 0 ? result : -1;
    }
}
