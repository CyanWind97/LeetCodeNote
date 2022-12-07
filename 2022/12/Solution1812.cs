using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1812
    /// title:  判断国际象棋棋盘中一个格子的颜色
    /// problems: https://leetcode.cn/problems/determine-color-of-a-chessboard-square/
    /// date: 20221208
    /// </summary>
    public static class Solution1812
    {
        public static bool SquareIsWhite(string coordinates) {
            return (coordinates[0] - 'a' + coordinates[1] - '1') % 2 != 0;
        }
    }
}