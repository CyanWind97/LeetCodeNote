using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2500
    /// title:  删除每行中的最大值
    /// problems: https://leetcode.cn/problems/delete-greatest-value-in-each-row/
    /// date: 20230727
    /// </summary>
    public static class Solution2500
    {
        public static int DeleteGreatestValue(int[][] grid) {
            int m = grid.Length;
            int n = grid[0].Length;
            
            foreach(var row in grid) {
                Array.Sort(row);
            }

            return Enumerable.Range(0, n)
                        .Select(j => Enumerable.Range(0, m).Max(i => grid[i][j]))
                        .Sum();

        }
    }
}