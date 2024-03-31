using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1627
    /// title: 统计参与通信的服务器
    /// problems: https://leetcode.cn/problems/count-servers-that-communicate/
    /// date: 20230824
    /// </summary>
    public static class Solution1627
    {
        public static int CountServers(int[][] grid) {
            (int m, int n) = (grid.Length, grid[0].Length);

            var rows = new int[m];
            var cols = new int[n];

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    if(grid[i][j] == 0)
                        continue;

                    rows[i]++;
                    cols[j]++;
                }
            }

            return Enumerable.Range(0, m)
                    .Sum(i => Enumerable.Range(0, n)
                                    .Count(j => grid[i][j] == 1 && (rows[i] > 1 || cols[j] > 1)));
        }
    }
}