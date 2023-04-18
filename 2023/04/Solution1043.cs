using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1043
    /// title:  分隔数组以得到最大和
    /// problems: https://leetcode.cn/problems/partition-array-for-maximum-sum/
    /// date: 20230419
    /// </summary>
    public static class Solution1043
    {
        public static int MaxSumAfterPartitioning(int[] arr, int k) {
            int length = arr.Length;
            var dp = new int[length + 1];

            for(int i = 1; i <= length; i++){
                int max = arr[i - 1];
                for(int j = i - 1; j >= 0 && j >= i - k; j--){
                    dp[i] = Math.Max(dp[i], dp[j] + max * (i - j));
                    if(j > 0)
                        max = Math.Max(max, arr[j - 1]);
                }
            }

            return dp[length];
        }
    }
}