using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2319
    /// title: 判断矩阵是否是一个 X 矩阵
    /// problems: https://leetcode.cn/problems/check-if-matrix-is-x-matrix/
    /// date: 20230131
    /// </summary>
    public static class Solution2319
    {
        public static bool CheckXMatrix(int[][] grid) {
            int n = grid.Length;

            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    if(i == j || i + j == n - 1){
                        if(grid[i][j] == 0)
                            return false;
                    }else if(grid[i][j] != 0){
                        return false;
                    }
                }
            }

            return true;
        }   
    }
}