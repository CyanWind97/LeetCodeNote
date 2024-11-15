using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3240
/// title: 最少翻转次数使二进制矩阵回文 II
/// problems: https://leetcode.cn/problems/minimum-number-of-flips-to-make-binary-grid-palindromic-ii/
/// date: 20241116
/// </summary>
public static class Solution3240
{
    public static int MinFlips(int[][] grid) {
        (int m, int n) = (grid.Length, grid[0].Length);
        int result = 0;

        for(int i = 0; i < m / 2; i++){
            for(int j = 0; j < n / 2; j++){
                int count = grid[i][j] + grid[^(i + 1)][j] + grid[i][^(j + 1)] + grid[^(i + 1)][^(j + 1)];
                result += Math.Min(count, 4 - count);
            }
        }

        int diff = 0;
        int count2 = 0;
        if ((m & 1) == 1){
            for(int j = 0; j < n / 2; j++){
                if (grid[m / 2][j] != grid[m / 2][^(j + 1)]){
                    diff++;
                }else if (grid[m / 2][j] == 1)
                    count2 += 2;
            }
        }

        if ((n & 1) == 1){
            for(int i = 0; i < m / 2; i++){
                if (grid[i][n / 2] != grid[^(i + 1)][n / 2]){
                    diff++;
                }else if (grid[i][n / 2] == 1)
                    count2 += 2;
            }
        }
        
        if ((m & 1) == 1 
            && (n & 1) == 1
            && grid[m / 2][n / 2] == 1)
            result++;
        
        if (diff > 0)
            result += diff;
        else
            result += count2 % 4;

        return result;
    }
}
