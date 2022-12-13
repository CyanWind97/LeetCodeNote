using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1697
    /// title:  检查边长度限制的路径是否存在
    /// problems: https://leetcode.cn/problems/checking-existence-of-edge-length-limited-paths/
    /// date: 20221214
    /// </summary>
    public static class Solution1697
    {
        // 参考解答
        // 并查集
        public static bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries) {
            Array.Sort(edgeList, (a, b) => a[2] - b[2]);

            int length = queries.Length;
            var index = Enumerable.Range(0, length).ToArray();

            Array.Sort(index, (a, b) => queries[a][2] - queries[b][2]);

            var uf = Enumerable.Range(0, n).ToArray();

            int Find(int[] uf, int x) {
                if (uf[x] == x) 
                    return x;
                
                return uf[x] = Find(uf, uf[x]);
            }

            void Merge(int[] uf, int x, int y) {
                x = Find(uf, x);
                y = Find(uf, y);
                uf[y] = x;
            }

            var result = new bool[length];
            int k = 0;
            foreach (int i in index) {
                while (k < edgeList.Length && edgeList[k][2] < queries[i][2]) {
                    Merge(uf, edgeList[k][0], edgeList[k][1]);
                    k++;
                }

                result[i] = Find(uf, queries[i][0]) == Find(uf, queries[i][1]);
            }

            return result;
        }
    }
}