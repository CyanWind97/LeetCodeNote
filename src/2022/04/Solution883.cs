using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 883
    /// title: 三维形体投影面积
    /// problems: https://leetcode-cn.com/problems/projection-area-of-3d-shapes/
    /// date: 20220426
    /// </summary>

    public static class Solution883
    {
        public static int ProjectionArea(int[][] grid) {
            var n = grid.Length;
            var maxR = new int[n];
            var maxC = new int[n];
            var count = 0;
            
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    if(grid[i][j] == 0)
                        continue;
                    
                    count++;
                    maxR[i] = Math.Max(maxR[i], grid[i][j]);
                    maxC[j] = Math.Max(maxC[j], grid[i][j]);
                }
            }
            
            return count + maxR.Sum() + maxC.Sum();
        }
    }
}