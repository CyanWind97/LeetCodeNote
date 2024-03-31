using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1260
    /// title: 二维网格迁移
    /// problems: https://leetcode.cn/problems/shift-2d-grid/
    /// date: 20220720
    /// </summary>
    public static class Solution1260
    {
        public static IList<IList<int>> ShiftGrid(int[][] grid, int k) {
            int m = grid.Length;
            int n = grid[0].Length;
            k %= (m * n);

            var result = new IList<int>[m];
            
            for(int i = 0; i < m; i++){
                result[i] = new int[n];
            }

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    var x = (i + ((k + j) / n)) % m;
                    var y = (k + j) % n;

                    result[x][y] = grid[i][j];
                }
            }

            return result;
        }
    }
}