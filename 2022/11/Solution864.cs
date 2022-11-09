using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 864
    /// title: 获取所有钥匙的最短路径
    /// problems: https://leetcode.cn/problems/shortest-path-to-get-all-keys/
    /// date: 20221110
    /// </summary> 
    public static class Solution864
    {
        // 参考解答
        // 状态压缩 + 广度优先搜索
        public static int ShortestPathAllKeys(string[] grid) {
            int[][] dirs = {new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1}};
            int m = grid.Length, n = grid[0].Length;
            int sx = 0, sy = 0;
            IDictionary<char, int> keyToIndex = new Dictionary<char, int>();
            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n; ++j) {
                    if (grid[i][j] == '@') {
                        sx = i;
                        sy = j;
                    } else if (char.IsLower(grid[i][j])) {
                        if (!keyToIndex.ContainsKey(grid[i][j])) {
                            int idx = keyToIndex.Count;
                            keyToIndex.Add(grid[i][j], idx);
                        }
                    }
                }
            }

            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            int[][][] dist = new int[m][][];
            for (int i = 0; i < m; ++i) {
                dist[i] = new int[n][];
                for (int j = 0; j < n; ++j) {
                    dist[i][j] = new int[1 << keyToIndex.Count];
                    Array.Fill(dist[i][j], -1);
                }
            }
            queue.Enqueue(new Tuple<int, int, int>(sx, sy, 0));
            dist[sx][sy][0] = 0;
            while (queue.Count > 0) {
                Tuple<int, int, int> tuple = queue.Dequeue();
                int x = tuple.Item1, y = tuple.Item2, mask = tuple.Item3;
                for (int i = 0; i < 4; ++i) {
                    int nx = x + dirs[i][0];
                    int ny = y + dirs[i][1];
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] != '#') {
                        if (grid[nx][ny] == '.' || grid[nx][ny] == '@') {
                            if (dist[nx][ny][mask] == -1) {
                                dist[nx][ny][mask] = dist[x][y][mask] + 1;
                                queue.Enqueue(new Tuple<int, int, int>(nx, ny, mask));
                            }
                        } else if (char.IsLower(grid[nx][ny])) {
                            int idx = keyToIndex[grid[nx][ny]];
                            if (dist[nx][ny][mask | (1 << idx)] == -1) {
                                dist[nx][ny][mask | (1 << idx)] = dist[x][y][mask] + 1;
                                if ((mask | (1 << idx)) == (1 << keyToIndex.Count) - 1) {
                                    return dist[nx][ny][mask | (1 << idx)];
                                }
                                queue.Enqueue(new Tuple<int, int, int>(nx, ny, mask | (1 << idx)));
                            }
                        } else {
                            int idx = keyToIndex[char.ToLower(grid[nx][ny])];
                            if ((mask & (1 << idx)) != 0 && dist[nx][ny][mask] == -1) {
                                dist[nx][ny][mask] = dist[x][y][mask] + 1;
                                queue.Enqueue(new Tuple<int, int, int>(nx, ny, mask));
                            }
                        }
                    }
                }
            }
            return -1;
        }
    }
}