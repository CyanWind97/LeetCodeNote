using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2741
/// title: 特别的排列
/// problems: https://leetcode.cn/problems/special-permutations
/// date: 20240626
/// </summary>
public static class Solution2741
{
    // 参考解答 
    // 状态压缩
    public static int SpecialPerm(int[] nums) {
        const int MOD = 1_000_000_007;
        int n = nums.Length;
        var f = new int[1 << n, n];

        for(int i = 0; i < n; i++){
            f[1 << i, i] = 1;
        }

        for (int mask = 1; mask < (1 << n); mask++){
            for (int i = 0; i < n; i++){
                if ((mask >> i & 1) == 0)
                    continue;
                
                for (int j = 0; j < n; j++){
                    if (i == j || (mask >> j & 1) == 0)
                        continue;
                    
                    if (nums[i] % nums[j] != 0 && nums[j] % nums[i] != 0)
                        continue;
                    
                    f[mask, i] = (f[mask, i] + f[mask ^ (1 << i), j]) % MOD;
                }
            }
        }

        int result = 0;
        for (int i = 0; i < n; i++){
            result = (result + f[(1 << n) - 1, i]) % MOD;
        }

        return result;
    }
}
