using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2843
/// title: 统计好整数的数目
/// problems: https://leetcode.cn/problems/find-the-count-of-good-integers
/// date: 20250412
/// </summary>
public static class Solution3272
{
    // 参考解答
    public static long CountGoodIntegers(int n, int k) {
        var dict = new HashSet<string>();
        int baseVal = (int)Math.Pow(10, (n - 1) / 2);
        int skip = n & 1;
        /* 枚举 n 个数位的回文数 */
        for (int i = baseVal; i < baseVal * 10; i++) {
            string s = i.ToString();
            s += new string(s.Reverse().Skip(skip).ToArray());
            long palindromicInteger = long.Parse(s);
            /* 如果当前回文数是 k 回文数 */
            if (palindromicInteger % k == 0) {
                char[] chars = s.ToCharArray();
                Array.Sort(chars);
                dict.Add(new string(chars));
            }
        }

        long[] factorial = new long[n + 1];
        factorial[0] = 1;
        for (int i = 1; i <= n; i++) {
            factorial[i] = factorial[i - 1] * i;
        }

        long ans = 0;
        foreach (string s in dict) {
            int[] cnt = new int[10];
            foreach (char c in s) {
                cnt[c - '0']++;
            }
            /* 计算排列组合 */
            long tot = (n - cnt[0]) * factorial[n - 1];
            foreach (int x in cnt) {
                tot /= factorial[x];
            }
            ans += tot;
        }

        return ans;
    }
}
