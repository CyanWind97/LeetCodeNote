using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3145
/// title: 大数组元素的乘积
/// problems: https://leetcode.cn/problems/find-products-of-elements-of-big-array
/// date: 20240823
/// </summary>
public static class Solution3145
{

    // 参考解答
    public static int[] FindProductsOfElements(long[][] queries)
    {
        long Pow(long n, long k, long mod){
            var result = 1L;
            for (; k > 0; k >>= 1){
                if ((k & 1) != 0)
                    result = result * n % mod;
            
                n = n * n % mod;
            }

            return result % mod;
        }

        long SumE(long k){
            var (result, count, sumB, n) = (0L, 0L, 0L, 0L);
            for (var b = (int)(64 - 1 - long.LeadingZeroCount(k + 1)); b > 0; b--){
                long c = (count << b) + ((long)b << (b - 1));
                if (c <= k){
                    k -= c;
                    result += (sumB << b) + ((b * (long)(b - 1) / 2l) << (b - 1));
                    count++;
                    sumB += b;
                    n |= 1L << b;
                }
            }

            if (count <= k){
                k -= count;
                result += sumB;
                n++;
            }

            for (; k > 0; k--){
                result += long.TrailingZeroCount(n);
                n &= n - 1;
            }

            return result;
        }

        return queries
            .Select(q => (int)Pow(2, SumE(q[1] + 1) - SumE(q[0]), q[2]))
            .ToArray();
    }

    // 参考解答
    // 二分查找
    public static int[] FindProductsOfElements_1(long[][] queries) {
        int PowMod(long x, long y, long mod){
            long result = 1;
            while(y != 0){
                if ((y & 1) != 0)
                    result = result * x % mod;

                x = x * x % mod;
                y >>= 1;
            }

            return (int)result;
        }

        long CountPow(long x){
            long result = 0;
            int sum = 0;

            for (int i = 60; i >= 0; i--) {
                if ((1L << i & x) != 0) {
                    result += 1L * sum * (1L << i);
                    sum += i;
                    
                    if (i > 0) {
                        result += 1L * i * (i - 1) / 2 * (1L << (i - 1));
                    }
                }
            }
            result += sum;
            return result;
        }

        long CountOne(long x){
            long result = 0;
            int sum = 0;

            for (int i = 60; i >= 0; i--) {
                if ((1L << i & x) != 0) {
                    result += 1L * sum * (1L << i);
                    sum += 1;
                    
                    if (i > 0) {
                        result += 1L * i * (1L << (i - 1));
                    }
                }
            }
            result += sum;
            return result;
        }

        long MidCheck(long x) {
            long l = 1, r = (long) 1e15;
            while (l < r) {
                long mid = (l + r) >> 1;
                if (CountOne(mid) >= x)
                    r = mid;
                else 
                    l = mid + 1;
            }

            return r;
        }

        
        int length = queries.Length;
        var results = new int[length];

        for (int i = 0; i < length; i++) {
            var (from, to, mod) = (queries[i][0] + 1, queries[i][1] + 1, queries[i][2]);
            var (l, r) = (MidCheck(from), MidCheck(to));
            long result = 1;
            long pre = CountOne(l - 1);
            for (int j = 0; j < 60; j++) {
                if ((1L << j & l) != 0) {
                    pre++;
                    if (pre >= from && pre <= to) 
                        result = result * (1L << j) % mod;
                }
            }

            if (r > l) {
                long bac = CountOne(r - 1);
                for (int j = 0; j < 60; j++) {
                    if ((1L << j & r) != 0) {
                        bac++;
                        if (bac >= from && bac <= to) 
                            result = result * (1L << j) % mod;
                    }
                }
            }

            if (r - l > 1) {
                long xs = CountPow(r - 1) - CountPow(l);
                result = result * PowMod(2L, xs, mod) % mod;
            }

            results[i] = (int)result;
        }

        return results;
    }


}