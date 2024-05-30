using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2965
/// title: 找出缺失和重复的数字
/// problems: https://leetcode.cn/problems/find-missing-and-repeated-values
/// date: 20240531
/// </summary>
public static class Solution2965
{
    public static int[] FindMissingAndRepeatedValues(int[][] grid) {
        int n = grid.Length;
        int[] count = new int[n * n + 1];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                count[grid[i][j]]++;
            }
        }

        int[] res = new int[2];
        for (int i = 1; i <= n * n; i++) {
            if (count[i] == 2) {
                res[0] = i;
            }
            if (count[i] == 0) {
                res[1] = i;
            }
        }
        
        return res;
    }
}
