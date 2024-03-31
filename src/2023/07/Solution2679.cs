using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2679
    /// title: 矩阵中的和
    /// problems: https://leetcode.cn/problems/sum-in-a-matrix/
    /// date: 20230704
    /// </summary>
    public static class Solution2679
    {
        public static int MatrixSum(int[][] nums) {
            int m = nums.Length;
            int n = nums[0].Length;
            var sum = new int[n];
             
            for(int i = 0; i < m; i++){
                Array.Sort(nums[i]);
                for(int j = 0; j < n; j++){
                    sum[j] = Math.Max(sum[j], nums[i][j]);
                }
            }

            return sum.Sum();
        }
    }
}