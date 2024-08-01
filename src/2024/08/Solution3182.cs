using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3182
/// title: 直角三角形
/// problems: https://leetcode.cn/problems/right-triangles
/// date: 20240802
/// </summary>
public static class Solution3182
{
    public static long NumberOfRightTriangles(int[][] grid) {
        (int m, int n) = (grid.Length, grid[0].Length);
        var rows = new List<List<int>>();
        var cols = new int[n];

        for(int i = 0; i < m; i++){
            var row = new List<int>();
            for(int j = 0; j < n; j++){
                if (grid[i][j] == 1){
                    row.Add(j);
                    cols[j]++;
                }
            }

            if (row.Count > 1)
                rows.Add(row);
        }   

        return rows.Sum(row => (long)(row.Count - 1) * row.Sum((int i) => cols[i] - 1));
    }
}
