using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2397
    /// title: 被列覆盖的最多行数
    /// problems: https://leetcode.cn/problems/maximum-rows-covered-by-columns/description/?envType=daily-question&envId=2024-01-04
    /// date: 20240104
    /// </summary>
    public static class Solution2397
    {
        public static int MaximumRows(int[][] matrix, int numSelect) {

            (int m, int n) = (matrix.Length, matrix[0].Length);
            var mask = new int[m];
            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    mask[i] += matrix[i][j] << j;
                }
            }

            int result = 0;
            int limit = 1 << n;
            for(int i = 0; i < limit; i++){
                if (BitCount(i) != numSelect)
                    continue;
                
                int t = 0;
                for(int j = 0; j < m; j++){
                    if ((mask[j] & i) == mask[j])
                        t++;
                }

                result = Math.Max(result, t);
            }

            return result;

            
            int BitCount(int i) {
                i = i - ((i >> 1) & 0x55555555);
                i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
                i = (i + (i >> 4)) & 0x0f0f0f0f;
                i = i + (i >> 8);
                i = i + (i >> 16);
                return i & 0x3f;
            }
        }
    }
}