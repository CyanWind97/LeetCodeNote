using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1687
    /// title:  从仓库到码头运输箱子
    /// problems: https://leetcode.cn/problems/delivering-boxes-from-storage-to-ports/
    /// date: 20221205
    /// </summary>
    public static class Solution1687
    {
        // 参考解答
        // 动态规划 + 单调队列
        public static int BoxDelivering(int[][] boxes, int portsCount, int maxBoxes, int maxWeight) {
            int n = boxes.Length;
            int[] p = new int[n + 1];
            int[] w = new int[n + 1];
            int[] neg = new int[n + 1];
            long[] W = new long[n + 1];
            for (int i = 1; i <= n; ++i) {
                p[i] = boxes[i - 1][0];
                w[i] = boxes[i - 1][1];
                if (i > 1) {
                    neg[i] = neg[i - 1] + (p[i - 1] != p[i] ? 1 : 0);
                }
                W[i] = W[i - 1] + w[i];
            }

            var opt = new LinkedList<int>();
            opt.AddLast(0);
            int[] f = new int[n + 1];
            int[] g = new int[n + 1];

            for (int i = 1; i <= n; ++i) {
                while (i - opt.First.Value > maxBoxes || W[i] - W[opt.First.Value] > maxWeight) {
                    opt.RemoveFirst();
                }

                f[i] = g[opt.First.Value] + neg[i] + 2;

                if (i != n) {
                    g[i] = f[i] - neg[i + 1];
                    while (opt.Count > 0 && g[i] <= g[opt.Last.Value]) {
                        opt.RemoveLast();
                    }
                    opt.AddLast(i);
                }
            }

            return f[n];
        }
    }
}