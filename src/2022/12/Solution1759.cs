using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1759
    /// title: 统计同构子字符串的数目
    /// problems: https://leetcode.cn/problems/count-number-of-homogenous-substrings/
    /// date: 20221226
    /// </summary>
    public static class Solution1759
    {
        // 参考解答
        public static int CountHomogenous(string s) {
            const int MOD = 1000000007;
            long res = 0;
            char prev = s[0];
            int cnt = 0;
            foreach (char c in s) {
                if (c == prev) {
                    cnt++;
                } else {
                    res += (long) (cnt + 1) * cnt / 2;
                    cnt = 1;
                    prev = c;
                }
            }
            res += (long) (cnt + 1) * cnt / 2;
            return (int) (res % MOD);
        }
    }
}