using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1815
    /// title: 得到新鲜甜甜圈的最多组数
    /// problems: https://leetcode.cn/problems/maximum-number-of-groups-getting-fresh-donuts/
    /// date: 20230122
    /// </summary>
    public static class Solution1815
    {
        // 参考解答
        // 状态压缩 动态规划
        public static int MaxHappyGroups(int batchSize, int[] groups) {
            const int K_WIDTH = 5;
            const int K_WIDTH_MASK = (1 << K_WIDTH) - 1;

            int[] cnt = new int[batchSize];
            foreach (int x in groups) {
                ++cnt[x % batchSize];
            }

            long start = 0;
            for (int i = batchSize - 1; i >= 1; --i) {
                start = (start << K_WIDTH) | cnt[i];
            }

            var memo = new Dictionary<long, int>();

            int DFS(long mask) {
                if (mask == 0) {
                    return 0;
                }

                if (!memo.ContainsKey(mask)) {
                    long total = 0;
                    for (int i = 1; i < batchSize; ++i) {
                        long amount = ((mask >> ((i - 1) * K_WIDTH)) & K_WIDTH_MASK);
                        total += i * amount;
                    }

                    int best = 0;
                    for (int i = 1; i < batchSize; ++i) {
                        long amount = ((mask >> ((i - 1) * K_WIDTH)) & K_WIDTH_MASK);
                        if (amount > 0) {
                            int result = DFS(mask - (1L << ((i - 1) * K_WIDTH)));
                            if ((total - i) % batchSize == 0) {
                                ++result;
                            }
                            best = Math.Max(best, result);
                        }
                    }

                    memo.Add(mask, best);
                }
                return memo[mask];
            }

            return DFS(start) + cnt[0];
        }
    }
}