using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1761
    /// title: 一个图中连通三元组的最小度数
    /// problems: https://leetcode.cn/problems/minimum-degree-of-a-connected-trio-in-a-graph/
    /// date: 20230831
    /// </summary>
    public static class Solution1761
    {
        public static int MinTrioDegree(int n, int[][] edges) {
            var grahs = new int[n, n];
            int[] degree = new int[n];

            foreach (int[] edge in edges) {
                int x = edge[0] - 1, y = edge[1] - 1;
                grahs[x,y] = grahs[y, x] = 1;
                ++degree[x];
                ++degree[y];
            }

            var result = int.MaxValue;
            for (int i = 0; i < n; ++i) {
                for (int j = i + 1; j < n; ++j) {
                    if (grahs[i, j] != 1) 
                        continue;
                        
                    for (int k = j + 1; k < n; ++k) {
                        if (grahs[i, k] != 1 || grahs[j, k] != 1) 
                            continue;
                               
                        result = Math.Min(result, degree[i] + degree[j] + degree[k] - 6);
                    }
                }
            }

            return result == int.MaxValue ? -1 : result;

        }

        // 参考解答 
        // 有向图
        public static int MinTrioDegree_1(int n, int[][] edges) {
            // 原图
            ISet<int>[] g = new ISet<int>[n];
            for (int i = 0; i < n; ++i) {
                g[i] = new HashSet<int>();
            }
            // 定向后的图
            IList<int>[] h = new IList<int>[n];
            for (int i = 0; i < n; ++i) {
                h[i] = new List<int>();
            }
            int[] degree = new int[n];

            foreach (int[] edge in edges) {
                int x = edge[0] - 1, y = edge[1] - 1;
                g[x].Add(y);
                g[y].Add(x);
                ++degree[x];
                ++degree[y];
            }
            foreach (int[] edge in edges) {
                int x = edge[0] - 1, y = edge[1] - 1;
                if (degree[x] < degree[y] || (degree[x] == degree[y] && x < y)) {
                    h[x].Add(y);
                } else {
                    h[y].Add(x);
                }
            }

            int ans = int.MaxValue;
            for (int i = 0; i < n; ++i) {
                foreach (int j in h[i]) {
                    foreach (int k in h[j]) {
                        if (g[i].Contains(k)) {
                            ans = Math.Min(ans, degree[i] + degree[j] + degree[k] - 6);
                        }
                    }
                }
            }

            return ans == int.MaxValue ? -1 : ans;
        }

    }
}