using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1072
    /// title: 按列翻转得到最大值等行数
    /// problems: https://leetcode.cn/problems/flip-columns-for-maximum-number-of-equal-rows/
    /// date: 20230515
    /// </summary>
    public static class Solution1072
    {
        public static int MaxEqualRowsAfterFlips(int[][] matrix) {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int result = 0;
            var count = new Dictionary<string, int>();

            for(int i = 0; i < m; i++){
                int[] row = matrix[i];
                if(row[0] == 1){
                    for(int j = 0; j < n; j++){
                        row[j] = 1 - row[j];
                    }
                }

                var key = string.Join("", row);
                if(count.ContainsKey(key))
                    count[key]++;
                else
                    count[key] = 1;

                result = Math.Max(result, count[key]);
            }

            return result;
        }
    }
}