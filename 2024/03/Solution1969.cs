using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1969
/// title: 数组元素的最小非零乘积
/// problems: https://leetcode.cn/problems/maximum-score-of-a-good-subarray
/// date: 20240320
/// </summary>
public static class Solution1969
{
    // 参考解答
    public static int MinNonZeroProduct(int p) {
        if (p == 1) 
            return 1;

        long mod = 1000000007;

        long FastPow(long x, long n) {
            long res = 1;
            for (; n != 0; n >>= 1) {
                if ((n & 1) != 0) 
                    res = res * x % mod;
                
                x = x * x % mod;
            }
            return res;
        }

        long x = FastPow(2, p) - 1;
        long y = (long) 1 << (p - 1);

        
        return (int) (FastPow(x - 1, y - 1) * x % mod);
    }
}
