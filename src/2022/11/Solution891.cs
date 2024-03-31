using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 891
    /// title: 子序列宽度之和
    /// problems: https://leetcode.cn/problems/sum-of-subsequence-widths/
    /// date: 20221118
    /// </summary> 
    public static class Solution891
    {   
        // 参考解答
        // 数学
        public static int SumSubseqWidths(int[] nums) {
            const int MOD = 1000000007;
            Array.Sort(nums);
            long res = 0;
            long x = nums[0], y = 2;
            for (int j = 1; j < nums.Length; j++) {
                res = (res + nums[j] * (y - 1) - x) % MOD;
                x = (x * 2 + nums[j]) % MOD;
                y = y * 2 % MOD;
            }
            
            return (int) ((res + MOD) % MOD);
        }
    }
}