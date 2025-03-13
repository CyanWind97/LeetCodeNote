using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3340
/// title: 检查平衡字符串
/// problems: https://leetcode.cn/problems/check-balanced-string
/// date: 20250314
/// </summary>
public static class Solution3340
{
    public static bool IsBalanced(string num) {
        int result = 0;
        for(int i = 0; i < num.Length; i++){
           if((i & 1) == 0)
                result += num[i] - '0';
            else
                result -= num[i] - '0';
        }

        return result == 0;
    }
}
