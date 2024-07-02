using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3099
/// title: 哈沙德数
/// problems: https://leetcode.cn/problems/harshad-number
/// date: 20240703
/// </summary>
public static class Solution3099
{
    public static int SumOfTheDigitsOfHarshadNumber(int x) {
        int num = x;
        int sum = 0;
        while(num > 0){
            sum += num % 10;
            num /= 10;
        }

        return x % sum == 0 
            ? sum 
            : -1;
    }
}
