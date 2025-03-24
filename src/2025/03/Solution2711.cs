using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 2711
/// title:  对角线上不同值的数量差
/// problems: https://leetcode.cn/problems/difference-of-number-of-distinct-values-on-diagonals
/// date: 20250325
/// </summary>
public static class Solution2711
{
    public static int[][] DifferenceOfDistinctValues(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        
        // 创建结果矩阵
        int[][] answer = new int[m][];
        for (int i = 0; i < m; i++) {
            answer[i] = new int[n];
        }
        
        // 计算每个单元格的答案
        for (int r = 0; r < m; r++) {
            for (int c = 0; c < n; c++) {
                // 计算左上对角线不同值的数量
                HashSet<int> topLeft = new HashSet<int>();
                int i = r - 1, j = c - 1;
                while (i >= 0 && j >= 0) {
                    topLeft.Add(grid[i][j]);
                    i--;
                    j--;
                }
                
                // 计算右下对角线不同值的数量
                HashSet<int> bottomRight = new HashSet<int>();
                i = r + 1;
                j = c + 1;
                while (i < m && j < n) {
                    bottomRight.Add(grid[i][j]);
                    i++;
                    j++;
                }
                
                // 计算差值的绝对值
                answer[r][c] = Math.Abs(topLeft.Count - bottomRight.Count);
            }
        }
        
        return answer;
    }
}
