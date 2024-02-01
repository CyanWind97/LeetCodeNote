using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1686
    /// title: 水壶问题
    /// problems: https://leetcode.cn/problems/stone-game-vi/description/?envType=daily-question&envId=2024-02-02
    /// date: 20240202
    /// </summary>
    public static class Solution1686
    {
        public static int StoneGameVI(int[] aliceValues, int[] bobValues) {
            int n = aliceValues.Length;
            var scores = aliceValues.Zip(bobValues, (a, b) => (a + b, a, b))
                .OrderByDescending(t => t.Item1)
                .ToList<(int Sum, int A, int B)>();

            var aScore = scores.Where((t, i) => i % 2 == 0).Sum(t => t.A);
            var bScore = scores.Where((t, i) => i % 2 == 1).Sum(t => t.B);

            return aScore.CompareTo(bScore);
        }
    }
}