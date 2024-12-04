using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2056
/// title: 棋盘上有效移动组合的数目
/// problems: https://leetcode.cn/problems/number-of-valid-move-combinations-on-chessboard
/// date: 20241205
/// </summary>

public static class Solution2056
{ 
    
    public static int CountCombinations(string[] pieces, int[][] positions) {
        int numCombinations = 0;
        int[][] pairs = new int[4][];
        CountCombinations(pieces, positions, 0, pieces.Length);
        return numCombinations;
        
        void CountCombinations(string[] pieces, int[][] positions, int i, int n) {
            if (i == n) {
                int moves = 0;
                int[][] pos = new int[n][];
                for (i = 0; i < n; i++) pos[i] = new int[]{positions[i][0], positions[i][1]};
                for (i = 0; i < n; i++) moves = Math.Max(moves, pairs[i][2]);
                for (int m = 1; m <= moves; m++) {
                    for (i = 0; i < n; i++) if (m <= pairs[i][2]) {
                        pos[i][0] += pairs[i][0];
                        pos[i][1] += pairs[i][1];
                    }
                    for (int x = 0; x < n; x++)
                        for (int y = 0; y < x; y++)
                            if (pos[x][0] == pos[y][0] && pos[x][1] == pos[y][1]) return;
                }
                numCombinations++;
                return;
            }
            for (int x = -1; x <= 1; x++)
            for (int y = -1; y <= 1; y++) {
                if (pieces[i] ==  "rook"  && x * x + y * y == 2) continue;
                if (pieces[i] == "bishop" && x * x + y * y == 1) continue;
                int moves = x == -1 && y == -1 ? Math.Min(positions[i][0] - 1, positions[i][1] - 1)
                        : x == -1 && y == +1 ? Math.Min(positions[i][0] - 1, 8 - positions[i][1])
                        : x == +1 && y == -1 ? Math.Min(8 - positions[i][0], positions[i][1] - 1)
                        : x == +1 && y == +1 ? Math.Min(8 - positions[i][0], 8 - positions[i][1])
                        : x == -1 && y == 0 ? positions[i][0] - 1
                        : y == -1 && x == 0 ? positions[i][1] - 1
                        : x == +1 && y == 0 ? 8 - positions[i][0]
                        : y == +1 && x == 0 ? 8 - positions[i][1] : 0;
                for (int m = x == 0 && y == 0 ? 0 : 1; m <= moves; m++) {
                    pairs[i] = new int[]{x, y, m};
                    CountCombinations(pieces, positions, i + 1, n);
                }
            }
            return;
            
        }

    }
}
