using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1289
    /// title: 下降路径最小和 II
    /// problems: https://leetcode.cn/problems/minimum-falling-path-sum-ii/
    /// date: 20230810
    /// </summary>
    public static class Solution1289
    {
        public static int MinFallingPathSum(int[][] grid) {
            int n = grid.Length;
            int m = grid[0].Length;
            int min1Index = -1;
            int min1 = 0;
            int min2 = 0;

            for(int i = 0; i < n; i++){
                int curMin1 = int.MaxValue;
                int curMin2 = int.MaxValue;
                int curMin1Index = 0;

                for(int j = 0; j < m; j++){
                    int num = grid[i][j] + (j == min1Index ? min2 : min1);
                    if(num < curMin1){
                        curMin2 = curMin1;
                        curMin1 = num;
                        curMin1Index = j;
                    }else if(num < curMin2){
                        curMin2 = num;
                    }
                }
                
                min1 = curMin1;
                min2 = curMin2;
                min1Index = curMin1Index;
            }

            return min1;
        }
    }
}