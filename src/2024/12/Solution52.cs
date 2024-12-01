using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 52
/// title: N 皇后 II
/// problems: https://leetcode.cn/problems/n-queens-ii
/// date: 20241202
/// </summary>
public static class Solution52
{
    public static int TotalNQueens(int n) {
        var result = 0;
        var queens = new int[n];
        Array.Fill(queens, -1);
        bool[] cols = new bool[n];
        bool[] diag1 = new bool[2 * n - 1];
        bool[] diag2 = new bool[2 * n - 1];

        void Backrack(int row){
            if (row == n){
                result++;
                return;
            }

            for(int col = 0; col < n; col++){
                if (cols[col] || diag1[row + col] || diag2[row - col + n - 1])
                    continue;
                
                queens[row] = col;
                cols[col] = true;
                diag1[row + col] = true;
                diag2[row - col + n - 1] = true;
                Backrack(row + 1);
                queens[row] = -1;
                cols[col] = false;
                diag1[row + col] = false;
                diag2[row - col + n - 1] = false;
            }
        }

        Backrack(0);

        return result;
    }
}
