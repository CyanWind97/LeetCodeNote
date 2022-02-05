using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1219
    /// title: 黄金矿工
    /// problems: https://leetcode-cn.com/problems/path-with-maximum-gold/
    /// date: 20220205
    /// </summary>
    public static class Solution1219
    {
        public  static int GetMaximumGold(int[][] grid) {
            int[][] dirs = {new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1}};
            var m = grid.Length;
            var n = grid[0].Length;
            var result = 0;

            void DFS(int x, int y, int gold) {
                gold += grid[x][y];
                result = Math.Max(result, gold);

                int rec = grid[x][y];
                grid[x][y] = 0;

                for (int d = 0; d < 4; ++d) {
                    int nx = x + dirs[d][0];
                    int ny = y + dirs[d][1];
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] > 0) {
                        DFS(nx, ny, gold);
                    }
                }

                grid[x][y] = rec;
            }


            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n; ++j) {
                    if (grid[i][j] != 0) {
                        DFS(i, j, 0);
                    }
                }
            }


            return result;
        }
    }
}