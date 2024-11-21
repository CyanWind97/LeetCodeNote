using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 3233
/// title: 统计不是特殊数字的数字数量
/// problems: https://leetcode.cn/problems/find-the-count-of-numbers-which-are-not-special
/// date: 20241122
/// </summary>
public static class Solution3233
{
    public static int NonSpecialCount(int l, int r) {
        int upper = (int) Math.Sqrt(r);
        int[] primes = new int[upper + 1];
        int result = r - l + 1;
        for (int i = 2; i <= upper; i++) {
            if (primes[i] != 0)
                continue;
            
            if (i * i >= l && i * i <= r) 
                result--;
            
            for (int j = i * 2; j <= upper; j += i) {
                primes[j] = 1;
            }
        }

        return result;
    }
}
