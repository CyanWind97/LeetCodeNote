using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2596
    /// title: 检查骑士巡视方案
    /// problems: https://leetcode.cn/problems/check-knight-tour-configuration/?envType=daily-question&envId=2023-09-13
    /// date: 20230913
    /// </summary>
    public static partial class Solution2596
    {
        public static bool CheckValidGrid(int[][] grid) {
            int n = grid.Length;
            if (n < 5)
                return false;
            
            if (grid[0][0] != 0)
                return false;
            
            var indices = new int[n * n, 2];
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    indices[grid[i][j], 0] = i;
                    indices[grid[i][j], 1] = j;
                }
            }

            for(int i = 1; i < n * n; i++){
                int dx = Math.Abs(indices[i,0] - indices[i - 1, 0]);
                int dy = Math.Abs(indices[i,1] - indices[i - 1, 1]);
                if (dx * dy != 2)
                    return false;
            }

            return true;
        }
    }
}