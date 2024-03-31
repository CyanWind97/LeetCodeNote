using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 233
    /// title: 数字 1 的个数
    /// problems: https://leetcode-cn.com/problems/number-of-digit-one/
    /// date: 20210813
    /// </summary>
    public static class Solution233
    {
        // 参考解答
        public static int CountDigitOne(int n) {
            long mulk = 1;
            int ans = 0;
            for (int k = 0; n >= mulk; ++k) {
                ans += (int) (n / (mulk * 10) * mulk) + (int) Math.Min(Math.Max(n % (mulk * 10) - mulk + 1, 0), mulk);
                mulk *= 10;
            }
            return ans;
        }
    }
}