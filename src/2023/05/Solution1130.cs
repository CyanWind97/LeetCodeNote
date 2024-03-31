using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1130
    /// title: 叶值的最小代价生成树
    /// problems: https://leetcode.cn/problems/minimum-cost-tree-from-leaf-values/
    /// date: 20230531
    /// </summary>
    public static class Solution1130
    {
        public static int MctFromLeafValues(int[] arr) {
            int length = arr.Length;
            int[,] dp = new int[length, length];
            int[,] max = new int[length, length];

            for(int i = 0; i < length; i++){
                max[i, i] = arr[i];
                for(int j = i + 1; j < length; j++){
                    max[i, j] = Math.Max(max[i, j - 1], arr[j]);
                }
            }

            for(int i = length - 2; i >= 0; i--){
                for(int j = i + 1; j < length; j++){
                    dp[i, j] = int.MaxValue;
                    for(int k = i; k < j; k++){
                        dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j] + max[i, k] * max[k + 1, j]);
                    }
                }
            }

            return dp[0, length - 1];
        }
    }
}