using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2834
/// title: 找出美丽数组的最小和
/// problems: https://leetcode.cn/problems/find-the-minimum-possible-sum-of-a-beautiful-array
/// date: 20240308
/// </summary>
public static class Solution2834
{
    public static int MinimumPossibleSum(int n, int target) {
        const int MOD = 1000000007;
        int m = target / 2;
        
        return n <= m 
            ? (int)((long) (1 + n) * n / 2 % MOD)
            : (int) (((long) (1 + m) * m / 2 + 
                ((long) target + target + (n - m) - 1) * (n - m) / 2) % MOD);
    }
}
