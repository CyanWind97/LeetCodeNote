using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3133
/// title: 数组最后一个元素的最小值
/// problems: https://leetcode.cn/problems/minimum-array-end
/// date: 20240822
/// </summary>
public static class Solution3133
{
    public static long MinEnd(int n, int x) {
        long bitCount = 128 - long.LeadingZeroCount(n) - long.LeadingZeroCount(x);
        long result = x;
        long m = n - 1;
        int j = 0;
        for(int i = 0; i < bitCount; i++){
            if (((result >> i) & 1) == 0){
                if(((m >> j) & 1) == 1)
                    result |= 1L << i;

                j++;
            }
        }

        return result;
    }
}
