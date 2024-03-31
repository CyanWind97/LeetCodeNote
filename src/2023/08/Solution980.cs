using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 980
    /// title: 不同路径 III
    /// problems: https://leetcode.cn/problems/unique-paths-iii/
    /// date: 20230804
    /// </summary>
    public static class Solution980
    {
        // 参考解答
        // 记忆回溯 + 状态压缩
        public static int UniquePathsIII(int[][] grid) {
            var dirs = new int[][]{new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1}};
            var memo = new Dictionary<int, int>();

            int DP(int i, int j, int st) {
                if (grid[i][j] == 2) 
                    return st == 0 ? 1 : 0;
                
                int r = grid.Length, c = grid[0].Length;
                int key = ((i * c + j) << (r * c)) + st;
                if (!memo.ContainsKey(key)) {
                    int res = 0;
                    foreach (int[] dir in dirs) {
                        int ni = i + dir[0], nj = j + dir[1];
                        if (ni >= 0 && ni < r && nj >= 0 && nj < c && (st & (1 << (ni * c + nj))) > 0) {
                            res += DP(ni, nj, st ^ (1 << (ni * c + nj)));
                        }
                    }
                    memo.Add(key, res);
                }
                return memo[key];
            }

            int r = grid.Length, c = grid[0].Length;
            int si = 0, sj = 0, st = 0;
            for (int i = 0; i < r; i++) {
                for (int j = 0; j < c; j++) {
                    if (grid[i][j] == 0 || grid[i][j] == 2) {
                        st |= 1 << (i * c + j);
                    } else if (grid[i][j] == 1) {
                        si = i;
                        sj = j;
                    }
                }
            }

            return DP(si, sj, st);
        }
        
    }
}