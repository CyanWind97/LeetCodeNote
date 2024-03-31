using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2681
    /// title: 英雄的力量
    /// problems: https://leetcode.cn/problems/power-of-heroes/
    /// date: 20230801
    /// </summary>
    public static class Solution2681
    {
        // 参考解答
        public static int SumOfPower(int[] nums) {
            const int mod = 1000000007;
            Array.Sort(nums);
            var dp = new int[nums.Length];
            var preSum = new int[nums.Length + 1];
            int res = 0; 
            for (int i = 0; i < nums.Length; i++) {
                dp[i] = (nums[i] + preSum[i]) % mod;
                preSum[i + 1] = (preSum[i] + dp[i]) % mod;

                res = (int) ((res + (long) nums[i] * nums[i] % mod * dp[i]) % mod);
                if (res < 0) 
                    res += mod;
            }

            return res;
        }
    }
}