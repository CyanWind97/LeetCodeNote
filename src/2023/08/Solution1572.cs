using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1572
    /// title: 矩阵对角线元素的和
    /// problems: https://leetcode.cn/problems/matrix-diagonal-sum/
    /// date: 20230811
    /// </summary>
    public static class Solution1572
    {
        public static int DiagonalSum(int[][] mat) {
            int n = mat.Length;
            int sum = Enumerable.Range(0, n)
                        .Sum(i => mat[i][i] + mat[i][n - i - 1]);
                        
            if(n % 2 == 1)
                sum -= mat[n / 2][n / 2];

            return sum;
        }
    }
}