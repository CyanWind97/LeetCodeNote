using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2617
/// title: 网格图中最少访问的格子数
/// problems: https://leetcode.cn/problems/minimum-number-of-visited-cells-in-a-grid
/// date: 20240322
/// </summary>
public static class Solution2617
{
    public static int MinimumVisitedCells(int[][] grid) {
        (int m, int n) = (grid.Length, grid[0].Length);
        var dist = new int[m, n];
        foreach (var i in Enumerable.Range(0, m))
            foreach (var j in Enumerable.Range(0, n))
                dist[i, j] = -1;
        
        dist[0, 0] = 1;
    

        var row = Enumerable.Range(0, m).Select(_ => new PriorityQueue<int, int>()).ToArray();
        var col = Enumerable.Range(0, n).Select(_ => new PriorityQueue<int, int>()).ToArray();

        int Dist(int x, int y)
            => x == -1 || y < x ? y : x;

        for (int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                while(row[i].Count > 0 && row[i].Peek() + grid[i][row[i].Peek()] < j)
                    row[i].Dequeue();

                if (row[i].Count > 0)
                    dist[i, j] = Dist(dist[i, j], dist[i, row[i].Peek()] + 1);

                while(col[j].Count > 0 && col[j].Peek() + grid[col[j].Peek()][j] < i)
                    col[j].Dequeue();
                
                if (col[j].Count > 0)
                    dist[i, j] = Dist(dist[i, j], dist[col[j].Peek(), j] + 1);

                if (dist[i, j] != -1){
                    row[i].Enqueue(j, dist[i, j]);
                    col[j].Enqueue(i, dist[i, j]);
                }
            }
        }

        return dist[m - 1, n - 1];
    }
}
