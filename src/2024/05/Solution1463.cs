using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1463
/// title: 摘樱桃 II
/// problems: https://leetcode.cn/problems/cherry-pickup-ii
/// date: 20240507
/// </summary>

public static partial class Solution1463
{
    // 参考解答 dp
    public static int CherryPickup(int[][] grid) {
        (int m, int n) = (grid.Length, grid[0].Length);
        var f = new int[n, n];
        var g = new int[n, n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                f[i, j] = -1;
                g[i, j] = -1;
            }
        }

        f[0, n - 1] = grid[0][0] + grid[0][n - 1];
        for (int i = 1; i < m; i++) {
            for (int j1 = 0; j1 < n; j1++){
                for(int j2 = 0; j2 < n; j2++){
                    int best = -1;
                    for (int dj1 = j1 - 1; dj1 <= j1 + 1; dj1++) {
                        for (int dj2 = j2 - 1; dj2 <= j2 + 1; dj2++) {
                            if (dj1 >= 0 && dj1 < n 
                            && dj2 >= 0 && dj2 < n) 
                                best = Math.Max(best, f[dj1, dj2]);
                        }
                    }
                    g[j1, j2] = best;
                }
            }
            (f, g) = (g, f);
        }

        int result = 0;
        for (int j1 = 0; j1 < n; j1++) {
            for (int j2 = 0; j2 < n; j2++) {
                result = Math.Max(result, f[j1, j2]);
            }
        }

        return result;
    }
}
