using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 878
    /// title: 第 N 个神奇数字
    /// problems: https://leetcode.cn/problems/nth-magical-number/
    /// date: 20221122
    /// </summary>
    public static class Solution878
    {
        // 参考解答
        public static int NthMagicalNumber(int n, int a, int b) {
            const int MOD = 1000000007;

            int LCM(int a, int b) 
                => a * b / GCD(a, b);

            int GCD(int a, int b) 
                => b != 0 ? GCD(b, a % b) : a;

            int c = LCM(a, b);
            int m = c / a + c / b - 1;
            int r = n % m;
            int res = (int) ((long) c * (n / m) % MOD);
            if (r == 0) {
                return res;
            }
            int addA = a, addB = b;
            for (int i = 0; i <  r - 1; ++i) {
                if (addA < addB) {
                    addA += a;
                } else {
                    addB += b;
                }
            }

            return (res + Math.Min(addA, addB) % MOD) % MOD;
        }
    }
}