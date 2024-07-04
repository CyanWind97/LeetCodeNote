using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3033
/// title: 修改矩阵
/// problems: https://leetcode.cn/problems/modify-the-matrix
/// date: 20240705
/// </summary>
public static class Solution3033
{
    public static int[][] ModifiedMatrix(int[][] matrix) {
        (int m, int n) = (matrix.Length, matrix[0].Length);
        var modified = new List<int>(m);
        int max = -1;
        for(int j = 0; j < n; j++){
            modified.Clear();
            max = -1;

            for (int i = 0; i < m; i++){
                if (matrix[i][j] == -1)
                    modified.Add(i);
                else
                    max = Math.Max(max, matrix[i][j]);
            }

            foreach(var i in modified){
                matrix[i][j] = max;
            }
        }

        return matrix;
    }
}
