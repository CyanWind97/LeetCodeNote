using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2710
/// title: 移除字符串中的尾随零
/// problems: https://leetcode.cn/problems/remove-trailing-zeros-from-a-string
/// date: 20240629
/// </summary>
public static class Solution2710
{
    public static string RemoveTrailingZeros(string num) {
        var span = num.AsSpan();
        int i = 1;

        while(i <= span.Length && span[^i] == '0')
            i++;
        
        return span[..^(i-1)].ToString();
    }
}
