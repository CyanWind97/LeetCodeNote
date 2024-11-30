using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 51
/// title: N 皇后
/// problems: https://leetcode.cn/problems/n-queens
/// date: 20241201
/// </summary>
public static class Solution51
{
    public static IList<IList<string>> SolveNQueens(int n) {
        var result = new List<IList<string>>();
        var queens = new int[n];
        Array.Fill(queens, -1);
        bool[] cols = new bool[n];
        bool[] diag1 = new bool[2 * n - 1];
        bool[] diag2 = new bool[2 * n - 1];

        void Backrack(int row){
            if (row == n){
                result.Add(Solve());
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

        IList<string> Solve(){
            var result = new List<string>();
            var buffer = new Span<char>(new char[n]);
            buffer.Fill('.');
            for(int i = 0; i < n; i++){
                buffer[queens[i]] = 'Q';
                result.Add(new string(buffer));
                buffer[queens[i]] = '.';
            }

            return result;
        }

        Backrack(0);

        return result;
    }
}
