using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 36
    /// title: 有效的数独
    /// problems: https://leetcode-cn.com/problems/valid-sudoku/
    /// date: 20210917
    /// </summary>
    public static class Solution36
    {
        public static bool IsValidSudoku(char[][] board) {
            var rowSets = new HashSet<int>[9];
            var columnSets = new HashSet<int>[9];
            var squaredSets = new HashSet<int>[9];

            int GetSquaredIndex(int row, int column) 
                => (row / 3) * 3 + column / 3;

            for(int i = 0; i < 9; i++){
                rowSets[i] = new HashSet<int>();
                columnSets[i] = new HashSet<int>();
                squaredSets[i] = new HashSet<int>();
            }

            for(int i = 0; i < 9; i++){
                for(int j = 0; j < 9; j++)
                {
                    if (!char.IsDigit(board[i][j]))
                        continue;

                    int num = board[i][j] - '0';
                    int squaredIndex = GetSquaredIndex(i, j);

                    if (rowSets[i].Add(num)
                        && columnSets[j].Add(num)
                        && squaredSets[squaredIndex].Add(num))
                        continue;
                    
                    return false;
                }
            }

            return true;
        }
    }
}