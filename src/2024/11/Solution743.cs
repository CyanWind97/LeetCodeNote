using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 743
/// title: 网络延迟时间
/// problems: https://leetcode-cn.com/problems/network-delay-time/
/// date: 20241125
/// </summary>
public static partial class Solution743
{
    
    // 参考 Dijkstra算法 + 贪心
    public static int NetworkDelayTime(int[][] times, int n, int k) {
        const int INF = int.MaxValue / 2;
        int[,] g = new int[n, n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                g[i, j] = INF;
            }
        }
        foreach (int[] t in times) {
            g[t[0] - 1, t[1] - 1] = t[2];
        }

        int[] dist = new int[n];
        Array.Fill(dist, INF);
        dist[k - 1] = 0;
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++) {
            int x = -1;
            for (int y = 0; y < n; y++) {
                if (!visited[y] && (x == -1 || dist[y] < dist[x]))
                    x = y;
            }
            visited[x] = true;
            for (int y = 0; y < n; y++) {
                dist[y] = Math.Min(dist[y], dist[x] + g[x, y]);
            }
        }

        int ans = dist.Max();
        return ans == INF ? -1 : ans;
    }
}
