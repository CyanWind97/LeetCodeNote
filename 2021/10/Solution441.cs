using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 441
    /// title: 排列硬币
    /// problems: https://leetcode-cn.com/problems/arranging-coins/
    /// date: 20211010
    /// </summary>
    public static class Solution441
    {
        public static int ArrangeCoins(int n) {
            return (int)Math.Floor(Math.Sqrt(2 * (long)n + 0.25) - 0.5);
        }
    }
}