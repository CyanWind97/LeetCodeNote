using System;
using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 08.12
    /// title:  08.12. 八皇后
    /// problems: https://leetcode.cn/problems/eight-queens-lcci/
    /// date: 20220517
    /// type: 面试题 lcci
    /// priority: 0078
    /// time: 00:03:29.18 timeout
    /// </summary>
    public class CodeTop_lcci_08_12
    {

        // 参考解答 集合回溯
        public static IList<IList<string>> SolveNQueens(int n) {
            var solutions = new List<IList<string>>();
            var queues = new int[n];
            Array.Fill(queues, -1);
            var columns = new HashSet<int>();
            var diagonals1 = new HashSet<int>();
            var diagonals2 = new HashSet<int>();

            List<string> GenerateBoard(){
                var board = new List<string>();
                for(int i = 0; i < n; i++){
                    var row = new char[n];
                    Array.Fill(row, '.');
                    row[queues[i]] = 'Q';
                    board.Add(new string(row));
                }

                return board;
            }

            void BackTrack(int row){
                if(row == n){
                    solutions.Add(GenerateBoard());
                    return;
                }

                for(int i = 0; i < n; i++){
                    if(!columns.Add(i))
                        continue;
                    
                    int diagonal1 = row - i;
                    if(!diagonals1.Add(diagonal1))
                        continue;
                    
                    int diagonal2 = row + i;
                    if(!diagonals2.Add(diagonal2))
                        continue;
                    
                    queues[row] = i;
                    
                    BackTrack(row + 1);
                    queues[row] = -1;
                    columns.Remove(i);
                    diagonals1.Remove(diagonal1);
                    diagonals2.Remove(diagonal2);
                }
            }

            BackTrack(0);

            return solutions;
        }
    }
}