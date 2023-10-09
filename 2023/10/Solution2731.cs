using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2731
    /// title: 移动机器人
    /// problems: https://leetcode.cn/problems/movement-of-robots/?envType=daily-question&envId=2023-10-10
    /// date: 20231010
    /// </summary>
    public static class Solution2731
    {
        public static int SumDistance(int[] nums, string s, int d) {
            const int MOD = 1000000007;
            int n = nums.Length;
            var pos = new long[n];
            for (int i = 0; i < n; ++i) {
                if (s[i] == 'L')
                    pos[i] = (long)nums[i] - d;
                else
                    pos[i] = (long)nums[i] + d;
            }

            Array.Sort(pos);
            long result = 0;
            for(int i = 1; i < n; i++){
                result += 1L * (pos[i] - pos[i - 1]) * i % MOD * (n - i) % MOD;
                result %= MOD;
            }

            return (int)result;
        }
    }
}