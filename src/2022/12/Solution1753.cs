using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1753
    /// title: 移除石子的最大得分
    /// problems: https://leetcode.cn/problems/maximum-score-from-removing-stones/
    /// date: 20221221
    /// </summary>
    public static class Solution1753
    {
        public static int MaximumScore(int a, int b, int c) {
            int sum = a + b + c;
            int max = Math.Max(Math.Max(a, b), c);

            return Math.Min(sum - max, sum / 2);
        }
    }
}