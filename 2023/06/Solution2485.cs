using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2485
    /// title: 找出中枢整数
    /// problems: https://leetcode.cn/problems/find-the-pivot-integer/
    /// date: 20230626
    /// </summary>
    public static class Solution2485
    {
        public static int PivotInteger(int n) {
            int t = (n * n + n) / 2;
            int x = (int) Math.Sqrt(t);

            return  x * x == t ? x : -1;
        }
    }
}