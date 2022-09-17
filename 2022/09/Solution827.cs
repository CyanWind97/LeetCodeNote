using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    // <summary>
    /// no: 827
    /// title: 最大人工岛
    /// problems: https://leetcode.cn/problems/making-a-large-island/
    /// date: 20220918
    /// </summary>
    public static class Solution827
    {
        // 参考解答
        // 标记岛屿 + 合并
        public static int LargestIsland(int[][] grid) {
            int[] d = {0, -1, 0, 1, 0};
            int n = grid.Length;
            int result = 0;
            int[][] tag = new int[n][];

            for (int i = 0; i < n; i++) {
                tag[i] = new int[n];
            }

            bool Valid(int x, int y) 
                => x >= 0 && x < n && y >= 0 && y < n;
            
            int DFS(int x, int y, int t) {
                int ans = 1;
                tag[x][y] = t;
                for (int i = 0; i < 4; i++) {
                    int x1 = x + d[i], y1 = y + d[i + 1];
                    if (Valid(x1, y1) && grid[x1][y1] == 1 && tag[x1][y1] == 0)
                        ans += DFS(x1, y1, t);
                    
                }

                return ans;
            }


            var area = new Dictionary<int, int>();
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (grid[i][j] == 1 && tag[i][j] == 0) {
                        int t = i * n + j + 1;
                        area.Add(t, DFS(i, j, t));
                        result = Math.Max(result, area[t]);
                    }
                }
            }
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (grid[i][j] == 0) {
                        int z = 1;
                        var connected = new HashSet<int>();
                        for (int k = 0; k < 4; k++) {
                            int x = i + d[k], y = j + d[k + 1];
                            if (!Valid(x, y) || tag[x][y] == 0 || connected.Contains(tag[x][y]))
                                continue;
                            
                            z += area[tag[x][y]];
                            connected.Add(tag[x][y]);
                        }
                        result = Math.Max(result, z);
                    }
                }
            }

            return result;
        }
    }
}