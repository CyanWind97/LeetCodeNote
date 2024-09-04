using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2860
/// title:  清除数字
/// problems: https://leetcode.cn/problems/clear-digits
/// date: 20240905
/// </summary>
public static class Solution3174
{
    public static string ClearDigits(string s) {
        var span = new Span<char>(new char[s.Length]);
        int write = 0;

        foreach (var c in s)
        {
            if(char.IsDigit(c))
            {
                if (write > 0)
                    write--;
                
                continue;
            }
            
            span[write++] = c;
        }

        return new string(span[..write]);
    }
}
