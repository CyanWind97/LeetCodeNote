using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 407
    /// title: 接雨水 II
    /// problems: https://leetcode-cn.com/problems/trapping-rain-water-ii/
    /// date: 20211103
    /// </summary>
    public static class Solution407
    {
        // 参考解答 广度优先  dijkstra最短路?
        public static int TrapRainWater(int[][] heightMap) {
            int m = heightMap.Length;
            int n = heightMap[0].Length;
            int[] dirs = {-1, 0, 1, 0, -1};
            int maxHeight = 0;
            
            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n; ++j) {
                    maxHeight = Math.Max(maxHeight, heightMap[i][j]);
                }
            }
            int[,] water = new int[m, n];
            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n; ++j){
                    water[i, j] = maxHeight;      
                }
            }  

            Queue<int[]> qu = new Queue<int[]>();
            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n; ++j) {
                    if (i == 0 || i == m - 1 || j == 0 || j == n - 1) {
                        if (water[i, j] > heightMap[i][j]) {
                            water[i, j] = heightMap[i][j];
                            qu.Enqueue(new int[]{i, j});
                        }
                    }
                }
            }

            while (qu.Count > 0) {
                int[] curr = qu.Dequeue();
                int x = curr[0];
                int y = curr[1];
                for (int i = 0; i < 4; ++i) {
                    int nx = x + dirs[i], ny = y + dirs[i + 1];
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n) {
                        continue;
                    }
                    if (water[x, y] < water[nx, ny] && water[nx, ny] > heightMap[nx][ny]) {
                        water[nx, ny] = Math.Max(water[x, y], heightMap[nx][ny]);
                        qu.Enqueue(new int[]{nx, ny});
                    }
                }
            }

            int res = 0;
            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n; ++j) {
                    res += water[i, j] - heightMap[i][j];
                }
            }
            return res;
        }
    }
}