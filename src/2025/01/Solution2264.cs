using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2264
/// title: 字符串中最大的 3 位相同数字
/// problems: https://leetcode.cn/problems/largest-3-same-digit-number-in-string
/// date: 20250108
/// </summary>
public static class Solution2264
{
    public static string LargestGoodInteger(string num) {
        char result = '\0';

        for(int i = 0; i < num.Length - 2; i++){
            if(num[i] != num[i + 1]
            || num[i] != num[i + 2]){
                continue;
            }

            if(result == '\0' || num[i] > result){
                result = num[i];
            }
        }

        return result == '\0' ? "" : new (result, 3);
    }
}
