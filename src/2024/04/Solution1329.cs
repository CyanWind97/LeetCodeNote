using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1329
/// title: 将矩阵按对角线排序
/// problems: https://leetcode.cn/problems/sort-the-matrix-diagonally
/// date: 20240429
/// </summary>
public static class Solution1329
{
    public static int[][] DiagonalSort(int[][] mat) {
        (int m, int n) = (mat.Length, mat[0].Length);
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                int x = i, y = j;
                while(x < m && y < n){
                    if(mat[x][y] < mat[i][j]){
                        (mat[x][y], mat[i][j]) = (mat[i][j], mat[x][y]);
                    }
                    x++;
                    y++;
                }
            }
        }

        return mat;
    }
}
