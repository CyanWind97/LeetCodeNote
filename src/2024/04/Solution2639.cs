using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2639
/// title:  查询网格图中每一列的宽度
/// problems: https://leetcode.cn/problems/find-the-width-of-columns-of-a-grid
/// date: 20240427
/// </summary>
public static class Solution2639
{
    public static int[] FindColumnWidth(int[][] grid) {
        (int m, int n) = (grid.Length, grid[0].Length);

        static int CalcLength(int num){
            var sign = Math.Sign(num);
            int count = 0;
            if (sign == 0)
                return 1;
            
            if (sign < 0){
                count = 1;
                num = -num;
            }

            while(num > 0){
                num /= 10;
                count++;
            }

            return count;
        }

        return Enumerable.Range(0, n)
            .Select(j => Enumerable.Range(0, m)
                .Select(i => CalcLength(grid[i][j]))
                .Max())
            .ToArray();
    }
}
