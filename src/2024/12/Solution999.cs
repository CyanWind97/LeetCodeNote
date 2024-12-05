using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 999
/// title: 可以被一步捕获的棋子数
/// problems: https://leetcode.cn/problems/available-captures-for-rook
/// date: 20241206
/// </summary>
public static class Solution999
{
    public static int NumRookCaptures(char[][] board) {
        var n = board.Length;
        (int X, int Y) rook = (0, 0);
        for(int i = 0; i < n; i++){
            for (int j = 0; j < n; j++){
                if(board[i][j] == 'R'){
                    rook = (i, j);
                    break;
                }
            }
        }

        var result = 0;
        var directios = new (int X, int Y)[]{(0, 1), (0, -1), (1, 0), (-1, 0)};

        foreach(var direction in directios){
            var (x, y) = rook;
            while(x >= 0 && x < n && y >= 0 && y < n){
                if(board[x][y] == 'B')
                    break;
                
                if(board[x][y] == 'p'){
                    result++;
                    break;
                }

                x += direction.X;
                y += direction.Y;
            }
        }

        return result;
    }
}
