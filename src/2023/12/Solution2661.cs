using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2661
    /// title: 找出叠涂元素
    /// problems: https://leetcode.cn/problems/first-completely-painted-row-or-column/description/?envType=daily-question&envId=2023-12-01
    /// date: 20231201
    /// </summary>
    public static class Solution2661
    {
        public static int FirstCompleteIndex(int[] arr, int[][] mat) {
            (int m, int n) = (mat.Length, mat[0].Length);
            
            var map = new int[m * n + 1];
            for(int i = 0; i < m * n; i++){
                map[arr[i]] = i;
            }

            var rowMin = mat.Select(row => row.Max(num => map[num]))
                            .Min();
            var colMin = Enumerable.Range(0, n)
                            .Select(j => Enumerable.Range(0, m).Max(i => map[mat[i][j]]))
                            .Min();

            return Math.Min(rowMin, colMin);
        }
    }
}