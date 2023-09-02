using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1921
    /// title: 消灭怪物的最大数量
    /// problems: https://leetcode.cn/problems/eliminate-maximum-number-of-monsters/?envType=daily-question&envId=2023-09-03
    /// date: 20230903
    /// </summary>
    public static class Solution1921
    {
        public static int EliminateMaximum(int[] dist, int[] speed) {
            int length = dist.Length;
            var turns = dist.Select((d, i) => (d - 1) / speed[i]).ToArray();

            Array.Sort(turns);

            return Enumerable.Range(0, length)
                        .FirstOrDefault(i => turns[i] < i, length);
        }
    }
}