using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 807
    /// title:  保持城市天际线
    /// problems: https://leetcode-cn.com/problems/max-increase-to-keep-city-skyline/
    /// date: 20211213
    /// </summary>
    public static partial class Solution807
    {
        public static int MaxIncreaseKeepingSkyline(int[][] grid) {
            int m = grid.Length;
            int n = grid[0].Length;

            var rowMaxs = new int[m];
            var columnMaxs = new int[n];

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    rowMaxs[i] = Math.Max(rowMaxs[i], grid[i][j]);
                    columnMaxs[j] = Math.Max(columnMaxs[j], grid[i][j]);
                }
            }

            int result = 0;

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    result += Math.Min(rowMaxs[i], columnMaxs[j]) - grid[i][j];
                }
            }

            return result;
        }
    }
}