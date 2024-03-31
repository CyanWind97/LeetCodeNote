using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1739
    /// title: 放置盒子
    /// problems: https://leetcode.cn/problems/largest-merge-of-two-strings/
    /// date: 20221225
    /// </summary>
    public static class Solution1739
    {
        // 参考解答
        // 解方程
        public static int MinimumBoxes(int n) {
            long G(int x) 
                => (long) x * (x + 1) * (x + 2) / 6;
    
            int i = (int) Math.Pow(6.0 * n, 1.0 / 3);
            if (G(i) < n) 
                i++;
            

            n = (int) (n - G(i - 1));
            int j = (int) Math.Ceiling(1.0 * (Math.Sqrt((long) 8 * n + 1) - 1) / 2);
            return (i - 1) * i / 2 + j;
        }
    }
}