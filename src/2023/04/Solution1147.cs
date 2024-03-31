using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1147
    /// title: 段式回文
    /// problems: https://leetcode.cn/problems/longest-chunked-palindrome-decomposition/
    /// date: 20230412
    /// </summary>
    public static class Solution1147
    {
        // 参考解答
        // 滚动哈希
        public static int LongestDecomposition(string text) {
            long[] pre1;
            long[] pre2;
            long[] pow1;
            long[] pow2;

            const int MOD1 = 1000000007;
            const int MOD2 = 1000000009;
            int base1, base2;
            var random = new Random();

            void Init(string s) {
                base1 = 1000000 + random.Next(9000000);
                base2 = 1000000 + random.Next(9000000);
                while (base2 == base1) {
                    base2 = 1000000 + random.Next(9000000);
                }
                int n = s.Length;
                pow1 = new long[n];
                pow2 = new long[n];
                pre1 = new long[n + 1];
                pre2 = new long[n + 1];
                pow1[0] = pow2[0] = 1;
                pre1[1] = pre2[1] = s[0];
                for (int i = 1; i < n; i ++) {
                    pow1[i] = (pow1[i - 1] * base1) % MOD1;
                    pow2[i] = (pow2[i - 1] * base2) % MOD2;
                    pre1[i + 1] = (pre1[i] * base1 + s[i]) % MOD1;
                    pre2[i + 1] = (pre2[i] * base2 + s[i]) % MOD2;
                }
            }

            long[] GetHash(int l, int r) {
                return new long[]{(pre1[r + 1] - ((pre1[l] * pow1[r + 1 - l]) % MOD1) + MOD1) % MOD1, (pre2[r + 1] - ((pre2[l] * pow2[r + 1 - l]) % MOD2) + MOD2) % MOD2};
            }

            Init(text);
            int n = text.Length;
            int res = 0;
            int l = 0, r = n - 1;
            while (l <= r) {
                int len = 1;
                while (l + len - 1 < r - len + 1) {
                    if (Enumerable.SequenceEqual(GetHash(l, l + len - 1), GetHash(r - len + 1, r))) {
                        res += 2;
                        break;
                    }
                    ++len;
                }
                if (l + len - 1 >= r - len + 1) {
                    ++res;
                }
                l += len;
                r -= len;
            }
            
            return res;
        }
    }
}