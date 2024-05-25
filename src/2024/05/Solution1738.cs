using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1738
/// title: 找出第 K 大的异或坐标值
/// problems: https://leetcode-cn.com/problems/find-kth-largest-xor-coordinate-value/
/// date: 20240526
/// </summary>
public static partial class Solution1738
{
     public static int KthLargestValue(int[][] matrix, int k) {
        int m = matrix.Length, n = matrix[0].Length;
        int[,] pre = new int[m + 1, n + 1];
        List<int> results = [];

        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                pre[i, j] = pre[i - 1, j] ^ pre[i, j - 1] ^ pre[i - 1, j - 1] ^ matrix[i - 1][j - 1];
                results.Add(pre[i, j]);
            }
        }

        return results.OrderByDescending(num => num).Skip(k - 1).First();
    }
}
