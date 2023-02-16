using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1139
    /// title: 最大的以 1 为边界的正方形
    /// problems: https://leetcode.cn/problems/largest-1-bordered-square/
    /// date: 20230217
    /// </summary>
    public static class Solution1139
    {
        public static int Largest1BorderedSquare(int[][] grid) {
            int m = grid.Length;
            int n = grid[0].Length;
            var rows = new int[m + 1, n + 1];
            var cols = new int[m + 1, n + 1];
            int maxBorder = 0;
            for(int i = 1; i <= m; i++){
                for(int j = 1; j <= n; j++){
                    if(grid[i - 1][j - 1] == 0)
                        continue;
                    
                    rows[i, j] = rows[i, j - 1] + 1;
                    cols[i, j] = cols[i - 1, j] + 1;

                    int border = Math.Min(rows[i, j], cols[i, j]);
                    while(rows[i - border + 1, j] < border || cols[i, j - border + 1] < border){
                        border--;
                    }

                    maxBorder = Math.Max(border, maxBorder);
                }
            }

            return maxBorder * maxBorder;
        }
    }
}