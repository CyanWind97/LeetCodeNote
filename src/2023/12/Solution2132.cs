using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2132
    /// title: 用邮票贴满网格图
    /// problems: https://leetcode.cn/problems/stamping-the-grid/description/?envType=daily-question&envId=2023-12-14
    /// date: 20231214
    /// </summary>
    public static class Solution2132
    {
        // 参考解答
        // 二维前缀和 + 二维差分
        public static bool PossibleToStamp(int[][] grid, int stampHeight, int stampWidth) {
            (int m, int n) = (grid.Length, grid[0].Length);
            var sum = new int[m + 2, n + 2];
            var diff = new int[m + 2, n + 2];

            for(int i = 1; i <= m; i++){
                for(int j = 1; j <= n; j++){
                    sum[i, j] = sum[i - 1, j] + sum[i, j - 1] - sum[i - 1, j - 1] + grid[i - 1][j - 1];
                }
            }

            for(int i = 1; i + stampHeight - 1 <= m; i++){
                for(int j = 1; j + stampWidth - 1 <= n; j++){
                    (int x, int y) = (i + stampHeight - 1, j + stampWidth - 1);
                    int curr = sum[x, y] - sum[i - 1, y] - sum[x, j - 1] + sum[i - 1, j - 1];
                    if (curr == 0){
                        diff[i, j]++;
                        diff[x + 1, j]--;
                        diff[i, y + 1]--;
                        diff[x + 1, y + 1]++;
                    }
                }
            }

            for(int i = 1; i <= m; i++){
                for(int j = 1; j <= n; j++){
                    diff[i, j] += diff[i - 1, j] + diff[i, j - 1] - diff[i - 1, j - 1];
                    if (diff[i, j] == 0 && grid[i - 1][j - 1] == 0)
                        return false;
                }
            }

            return true;
        }
    }
}