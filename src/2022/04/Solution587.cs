using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 587
    /// title: 安装栅栏
    /// problems: https://leetcode-cn.com/problems/erect-the-fence/
    /// date: 20220423
    /// </summary>
    public static class Solution587
    {
        // 参考解答 凸包算法
        // Andrew 算法
        public static int[][] OuterTrees(int[][] trees) {
            int n = trees.Length;
            if (n < 4) 
                return trees;
            
            int Cross(int[] p, int[] q, int[] r) 
                => (q[0] - p[0]) * (r[1] - q[1]) - (q[1] - p[1]) * (r[0] - q[0]);
            


            /* 按照 x 大小进行排序，如果 x 相同，则按照 y 的大小进行排序 */
            Array.Sort(trees, (a, b) => {
                if (a[0] == b[0]) {
                    return a[1] - b[1];
                }
                return a[0] - b[0];
            });
            
            var hull = new List<int>();
            bool[] used = new bool[n];
            /* hull[0] 需要入栈两次，不进行标记 */
            hull.Add(0);
            /* 求出凸包的下半部分 */
            for (int i = 1; i < n; i++) {
                while (hull.Count > 1 && Cross(trees[hull[hull.Count - 2]], trees[hull[hull.Count - 1]], trees[i]) < 0) {
                    used[hull[hull.Count - 1]] = false;
                    hull.RemoveAt(hull.Count - 1);
                }
                used[i] = true;
                hull.Add(i);
            }
            int m = hull.Count;
            /* 求出凸包的上半部分 */
            for (int i = n - 2; i >= 0; i--) {
                if (!used[i]) {
                    while (hull.Count > m && Cross(trees[hull[hull.Count - 2]], trees[hull[hull.Count - 1]], trees[i]) < 0) {
                        used[hull[hull.Count - 1]] = false;
                        hull.RemoveAt(hull.Count - 1);
                    }
                    used[i] = true;
                    hull.Add(i);
                }
            }
            /* hull[0] 同时参与凸包的上半部分检测，因此需去掉重复的 hull[0] */
            hull.RemoveAt(hull.Count - 1);
            int size = hull.Count;
            int[][] res = new int[size][];
            for (int i = 0; i < size; i++) {
                res[i] = trees[hull[i]];
            }
            return res;
        }
    }
}