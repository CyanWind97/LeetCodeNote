using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 822
    /// title: 翻转卡片游戏
    /// problems: https://leetcode.cn/problems/card-flipping-game/
    /// date: 20230802
    /// </summary>
    public static class Solution822
    {
        public static int Flipgame(int[] fronts, int[] backs) {
            var set = Enumerable.Range(0, fronts.Length)
                .Where(i => fronts[i] == backs[i])
                .Select(i => fronts[i])
                .ToHashSet();

            return fronts.Concat(backs)
                .Where(x => !set.Contains(x))
                .DefaultIfEmpty()
                .Min();
        }
    }
}