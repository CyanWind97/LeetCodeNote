using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3007
/// title: 价值和小于等于 K 的最大数字
/// problems: https://leetcode.cn/problems/maximum-number-that-sum-of-the-prices-is-less-than-or-equal-to-k
/// date: 20240821
/// </summary>
public static class Solution3007
{
    // 二分查找
    public static long FindMaximumNumber(long k, int x) {
        (long l , long r) = (1, (k + 1) << x);

        long AccumulatePrice(int x, long num){
            long result = 0;
            long length = 64 - long.LeadingZeroCount(num);
            for (int i = x; i <= length; i+=x) {
                result += AccumulateBitPrice(i, num);
            }

            return result;
        }

        long AccumulateBitPrice(int x, long num){
            long period = 1L << x;
            long result = (period / 2) * (num / period);
            if (num % period >= (period / 2))
                result += num % period - (period >> 1) + 1;

            return result;
        }

        while(l < r){
            long m = (l + r + 1) >> 1;
            if(AccumulatePrice(x, m) > k)
                r = m - 1;
            else
                l = m;
        }

        return l;
    }
}
