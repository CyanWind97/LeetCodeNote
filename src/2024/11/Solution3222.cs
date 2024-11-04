using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3222
/// title: 求出硬币游戏的赢家
/// problems: https://leetcode.cn/problems/find-the-winning-player-in-coin-game/
/// date: 20241105
/// </summary>
public static class Solution3222
{
    public static string LosingPlayer(int x, int y) {
        var z =  x > y / 4 ? y / 4 : x;
        return z % 2 == 1 ? "Alice" : "Bob";
    }
}
