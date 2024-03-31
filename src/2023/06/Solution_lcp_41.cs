using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 41
    /// title: 黑白翻转棋
    /// problems: https://leetcode.cn/problems/fHi6rV/
    /// date: 20230621
    /// type: lcp
    /// </summary>
    public static class Solution_lcp_41
    {
        public static int FlipChess(string[] chessboard) {
            int m = chessboard.Length;
            int n = chessboard[0].Length;
            var board = new char[m, n];
            var dirs = new (int X, int Y)[]
            { 
                (0, 1), (1, 1), (1, 0), (1, -1),
                (0, -1), (-1, -1), (-1, 0), (-1, 1),
            };

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    board[i, j] = chessboard[i][j];
                }
            }
            
            int result = 0;

            int BFS(int i, int j){
                var copyBoard = new char[m, n];
                Array.Copy(board, copyBoard, m * n);
                var queue = new Queue<(int X, int Y)>();
                queue.Enqueue((i, j));
                copyBoard[i, j] = 'X';
                var count = 0;

                while(queue.Count > 0){
                    var (x, y) = queue.Dequeue();
                    
                    foreach(var dir in dirs){
                        var list = new List<(int X, int Y)>();
                        int nextX = x + dir.X;
                        int nextY = y + dir.Y;
                        var canFlip = false;
                        while(nextX >= 0 && nextX < m 
                            && 0 <= nextY && nextY < n ){
                            if(copyBoard[nextX, nextY] == 'X'){
                                canFlip = true;
                                break;
                            }

                            if (copyBoard[nextX, nextY] == '.'){
                                break;
                            }

                            list.Add((nextX, nextY));
                            nextX += dir.X;
                            nextY += dir.Y;
                        }

                        if (canFlip && list.Count > 0){
                            count += list.Count;
                            foreach(var (x1, y1) in list){
                                copyBoard[x1, y1] = 'X';
                                queue.Enqueue((x1, y1));
                            }
                        }
                    }

                }

                return count;
            }


            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    if (board[i, j] != '.')
                        continue;
                    
                    result = Math.Max(BFS(i, j), result);
                }
            }

            return result;
        }
    }
}