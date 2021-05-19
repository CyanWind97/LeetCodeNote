using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1738
    /// title: 找出第 K 大的异或坐标值
    /// problems: https://leetcode-cn.com/problems/find-kth-largest-xor-coordinate-value/
    /// date: 20210519
    /// </summary>
    public static class Solution1738
    {
        public static int KthLargestValue(int[][] matrix, int k) {
            int m = matrix.Length, n = matrix[0].Length;
            int[,] pre = new int[m + 1, n + 1];
            List<int> results = new List<int>();
            for (int i = 1; i <= m; ++i) {
                for (int j = 1; j <= n; ++j) {
                    pre[i, j] = pre[i - 1, j] ^ pre[i, j - 1] ^ pre[i - 1, j - 1] ^ matrix[i - 1][j - 1];
                    results.Add(pre[i, j]);
                }
            }

            results.Sort(
                delegate(int num1, int num2) {
                    return num2 - num1;
                }
            );
            return results[k - 1];
        }
    }
}