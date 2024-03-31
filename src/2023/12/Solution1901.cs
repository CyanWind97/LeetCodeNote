using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1901
    /// title: 寻找峰值 II
    /// problems: https://leetcode.cn/problems/find-a-peak-element-ii/description/?envType=daily-question&envId=2023-12-19
    /// date: 20231219
    /// </summary>
    public static class Solution1901
    {
        // 参考解答
        // 二分
        public static int[] FindPeakGrid(int[][] mat) {
            (int m, int n) = (mat.Length, mat[0].Length);
            (int low, int high) = (0, m - 1);
            while(low <= high){
                int i = (low + high) / 2;
                int j = -1;
                int max = -1;

                for(int k = 0; k < n; k++){
                    if (mat[i][k] > max){
                        j = k;
                        max = mat[i][k];
                    }
                }

                if (i - 1 >= 0 && mat[i][j] < mat[i - 1][j]){
                    high = i - 1;
                    continue;
                }

                if (i + 1 < m && mat[i][j] < mat[i + 1][j]){
                    low = i + 1;
                    continue;
                }

                return new int[]{i, j};
            }

            return Array.Empty<int>();
        }
    }
}