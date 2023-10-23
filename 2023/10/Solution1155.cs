using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1155
    /// title: 掷骰子等于目标和的方法数
    /// problems: https://leetcode.cn/problems/number-of-dice-rolls-with-target-sum/?envType=daily-question&envId=2023-10-24
    /// date: 20231024
    /// </summary>
    public static class Solution1155
    {
        public static int NumRollsToTarget(int n, int k, int target) {
            const int MOD = 1000000007;
            int[] f = new int[target + 1];
            f[0] = 1;
            for (int i = 1; i <= n; ++i) {
                for (int j = target; j >= 0; --j) {
                    f[j] = 0;
                    for (int x = 1; x <= k; ++x) {
                        if (j - x >= 0) {
                            f[j] = (f[j] + f[j - x]) % MOD;
                        }
                    }
                }
            }
            
            return f[target];
        }
    }
}