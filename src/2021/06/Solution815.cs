using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 815
    /// title: 公交路线
    /// problems: https://leetcode-cn.com/problems/bus-routes/
    /// date: 20210628
    /// </summary>
    public static partial class Solution815
    {
        // 参考解答 优化建图 + 广度优先搜索
        public static int NumBusesToDestination(int[][] routes, int source, int target) {
            if (source == target) {
                return 0;
            }

            int n = routes.Length;
            bool[,] edge = new bool[n, n];
            Dictionary<int, IList<int>> rec = new Dictionary<int, IList<int>>();
            for (int i = 0; i < n; i++) {
                foreach (int site in routes[i]) {
                    IList<int> list = new List<int>();
                    if (rec.ContainsKey(site)) {
                        list = rec[site];
                        foreach (int j in list) {
                            edge[i, j] = edge[j, i] = true;
                        }
                        rec[site].Add(i);
                    } else {
                        list.Add(i);
                        rec.Add(site, list);
                    }
                }
            }

            int[] dis = new int[n];
            Array.Fill(dis, -1);
            Queue<int> que = new Queue<int>();
            if (rec.ContainsKey(source)) {
                foreach (int bus in rec[source]) {
                    dis[bus] = 1;
                    que.Enqueue(bus);
                }
            }
            while (que.Count > 0) {
                int x = que.Dequeue();
                for (int y = 0; y < n; y++) {
                    if (edge[x, y] && dis[y] == -1) {
                        dis[y] = dis[x] + 1;
                        que.Enqueue(y);
                    }
                }
            }

            int ret = int.MaxValue;
            if (rec.ContainsKey(target)) {
                foreach (int bus in rec[target]) {
                    if (dis[bus] != -1) {
                        ret = Math.Min(ret, dis[bus]);
                    }
                }
            }
            return ret == int.MaxValue ? -1 : ret;
        }
    }
}