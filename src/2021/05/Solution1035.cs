using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1035
    /// title: 不相交的线
    /// problems: https://leetcode-cn.com/problems/uncrossed-lines/
    /// date: 20210521
    /// </summary>
    public static partial class Solution1035
    {
        public static int MaxUncrossedLines(int[] nums1, int[] nums2) {
            int m = nums1.Length;
            int n = nums2.Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++) {
                int num1 = nums1[i - 1];
                for (int j = 1; j <= n; j++) {
                    int num2 = nums2[j - 1];
                    if (num1 == num2) {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    } else {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            
            return dp[m, n];
        }
    }
}