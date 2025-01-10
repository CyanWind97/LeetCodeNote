using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3270
/// title: 求出数字答案
/// problems: https://leetcode.cn/problems/find-the-key-of-the-numbers
/// date: 20250111
/// </summary>
public static class Solution3270
{
    public static int GenerateKey(int num1, int num2, int num3) {
        int key = 0;
        for(int t = 1;  num1 > 0 && num2 > 0 && num3 > 0; t*=10){
            key += int.Min(num1 % 10, int.Min(num2 % 10, num3 % 10)) * t;
            num1 /= 10;
            num2 /= 10;
            num3 /= 10;
        }

        return key;
    }
}
