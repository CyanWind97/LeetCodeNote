using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1958
/// title: 检查操作是否合法
/// problems: https://leetcode.cn/problems/check-if-move-is-legal
/// date: 20240707
/// </summary>
public static class Solution1958
{
    public static bool CheckMove(char[][] board, int rMove, int cMove, char color) {
        (int m, int n) = (board.Length, board[0].Length);
        (int X, int Y)[] directions = [
            (-1, 0), (1, 0), 
            (0, -1), (0, 1),
            (1, -1), (1, 1), 
            (-1, -1), (-1, 1),
        ];

        char fill = color == 'B' ? 'W' : 'B';

        bool IsValid((int X, int Y) direction){
            int x = rMove + direction.X;
            int y = cMove + direction.Y;

            bool IsValidPoint()
                => x >= 0 && x < m && y >= 0 && y < n;

            int fillCount = 0;

            for(; IsValidPoint(); x += direction.X, y += direction.Y){
                if(board[x][y] == fill)
                    fillCount++;
                else if(board[x][y] == color)
                    return fillCount > 0;
                else
                    return false;
            }

            return false;
        }

        return directions.Any(IsValid);
    }
}
