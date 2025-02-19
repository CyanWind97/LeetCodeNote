using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2595
/// title: 奇偶位数
/// problems: https://leetcode.cn/problems/number-of-even-and-odd-bits
/// date: 20250220
/// </summary>
public static class Solution2595
{
    public static int[] EvenOddBit(int n) {
        var result = new int[2];
        int i = 0;
        while(n > 0){
            if ((n & 1) == 1)
                result[i]++;
            
            n >>= 1;
            i ^= 1;
        }

        return result;
    }
}
