using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3238
/// title: 求出胜利玩家的数目
/// problems: https://leetcode.cn/problems/find-the-number-of-winning-players
/// date: 20241123
/// </summary>
public static class Solution3238
{
    public static int WinningPlayerCount(int n, int[][] pick) {
        var count = Enumerable.Range(0, n).Select(_ => new Dictionary<int, int>()).ToArray();
        foreach(var p in pick){
            (int x, int y) = (p[0], p[1]);

            if (!count[x].ContainsKey(y))
                count[x][y] = 0;

            count[x][y]++;
        }

        return count
                .Where((d, x) => d.Values.Any(y => y > x))
                .Count();
    }
}
