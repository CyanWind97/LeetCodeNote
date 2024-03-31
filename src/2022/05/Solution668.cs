using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 668
    /// title: 乘法表中第k小的数
    /// problems: https://leetcode.cn/problems/kth-smallest-number-in-multiplication-table/
    /// date: 20220518
    /// </summary>
    public static class Solution668
    {
        // 参考解答 二分查找
        // 统计小于 x 的数量的方法
        public static int FindKthNumber(int m, int n, int k) {
            int left = 1, right = m * n;
            while (left < right) {
                int x = left + (right - left) / 2;
                int count = x / n * n;

                for (int i = x / n + 1; i <= m; ++i) {
                    count += x / i;
                }

                if (count >= k) 
                    right = x;
                else
                    left = x + 1;
            }

            return left;
        }
    }
}