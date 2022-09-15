using System.Collections.Generic;

namespace LeetCodeNote
{
    // <summary>
    /// no: 850
    /// title: 矩形面积 II
    /// problems: https://leetcode.cn/problems/rectangle-area-ii/
    /// date: 20220916
    /// </summary>
    public static class Solution850
    {
        // 参考解答
        // 离散化 + 扫描线 + 简单数组维护
        public static int RectangleArea(int[][] rectangles) {
            const int MOD = 1000000007;
            int length = rectangles.Length;
            var set = new HashSet<int>();
            foreach (int[] rect in rectangles) {
                // 下边界
                set.Add(rect[1]);
                // 上边界
                set.Add(rect[3]);
            }
            var hbound = new List<int>(set);
            hbound.Sort();
            int m = hbound.Count;
            // 「思路与算法部分」的 length 数组并不需要显式地存储下来
            // length[i] 可以通过 hbound[i+1] - hbound[i] 得到
            int[] seg = new int[m - 1];

            var sweep = new List<(int Bound, int Index, int Diff)>();
            for (int i = 0; i < length; ++i) {
                // 左边界
                sweep.Add((rectangles[i][0], i, 1));
                // 右边界
                sweep.Add((rectangles[i][2], i, -1));
            }
            sweep.Sort();

            long result = 0;
            for (int i = 0; i < sweep.Count; ++i) {
                int j = i;
                while (j + 1 < sweep.Count && sweep[i].Bound == sweep[j + 1].Bound) {
                    ++j;
                }
                if (j + 1 == sweep.Count) {
                    break;
                }
                // 一次性地处理掉一批横坐标相同的左右边界
                for (int k = i; k <= j; ++k) {
                    (_, int index, int diff) = sweep[k];
                    int left = rectangles[index][1], right = rectangles[index][3];
                    for (int x = 0; x < m - 1; ++x) {
                        if (left <= hbound[x] && hbound[x + 1] <= right) {
                            seg[x] += diff;
                        }
                    }
                }
                int cover = 0;
                for (int k = 0; k < m - 1; ++k) {
                    if (seg[k] > 0) {
                        cover += (hbound[k + 1] - hbound[k]);
                    }
                }
                result += (long) cover * (sweep[j + 1].Bound - sweep[j].Bound);
                i = j;
            }

            return (int) (result % MOD);
        }
    }
}