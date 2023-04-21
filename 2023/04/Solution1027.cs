using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1027
    /// title: 最长等差数列
    /// problems: https://leetcode.cn/problems/longest-arithmetic-subsequence/
    /// date: 20230422
    /// </summary>
    public static class Solution1027
    {
        public static int LongestArithSeqLength(int[] nums) {
            int length = nums.Length;
            int max = nums.Max();
            int min = nums.Min();
            int diff = max - min;
            int result = 1;

            var dp = new int[length, 2 * diff + 1];

            for(int i = 1; i < length; i++){
                for(int j = 0; j < i; j++){
                    int d = nums[i] - nums[j] + diff;
                    dp[i, d] = dp[j, d] + 1;
                    result = Math.Max(result, dp[i, d]);
                }
            }

            return result + 1;
        }
    }
}