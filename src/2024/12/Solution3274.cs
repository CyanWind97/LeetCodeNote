using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3274
/// title: 检查棋盘方格颜色是否相同
/// problems: https://leetcode.cn/problems/check-if-two-chessboard-squares-have-the-same-color
/// date: 20241203
/// </summary>
public static class Solution3274
{
    public static bool CheckTwoChessboards(string coordinate1, string coordinate2) {
        return (coordinate1[0] + coordinate1[1]  - (coordinate2[0] + coordinate2[1])) % 2 == 0;
    }
}
