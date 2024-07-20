using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1186
    /// title: 删除一次得到子数组最大和
    /// problems: https://leetcode.cn/problems/maximum-subarray-sum-with-one-deletion/
    /// date: 20230627
    /// </summary>
    public static partial class Solution1186
    {
        public static int MaximumSum(int[] arr) {
            int length = arr.Length;
            int max = arr[0];
            int dp0 = arr[0];
            int dp1 = 0;

            for(int i = 1; i < length; i++){
                dp1 = Math.Max(dp0, dp1 + arr[i]);
                dp0 = Math.Max(dp0, 0) + arr[i];
                max = Math.Max(max, Math.Max(dp0, dp1));
            }

            return max;
        }
    }
}