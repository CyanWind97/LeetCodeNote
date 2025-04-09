using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2999
/// title: 统计强大整数的数目
/// problems: https://leetcode.cn/problems/count-the-number-of-powerful-integers
/// date: 20250410
/// </summary>
public static class Solution2999
{

    // 参考解答
    public static long NumberOfPowerfulInt(long start, long finish, int limit, string s) {

        long Calculate(string x) {
            if (x.Length < s.Length) {
                return 0;
            }
            if (x.Length == s.Length) {
                return string.Compare(x, s) >= 0 ? 1 : 0;
            }

            string suffix = x.Substring(x.Length - s.Length);
            long count = 0;
            int preLen = x.Length - s.Length;

            for (int i = 0; i < preLen; i++) {
                int digit = x[i] - '0';
                if (limit < digit) {
                    count += (long) Math.Pow(limit + 1, preLen - i);
                    return count;
                }
                count += (long) digit * (long) Math.Pow(limit + 1, preLen - 1 - i);
            }
            if (string.Compare(suffix, s) >= 0) {
                count++;
            }
            return count;
        }

        string startS = (start - 1).ToString();
        string finishS = finish.ToString();
        return Calculate(finishS) - Calculate(startS);
    }
    
}
