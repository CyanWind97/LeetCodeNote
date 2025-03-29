using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2109
/// title:  向字符串添加空格
/// problems: https://leetcode.cn/problems/adding-spaces-to-a-string
/// date: 20250330
/// </summary>
public static class Solution2109
{
    public static string AddSpaces(string s, int[] spaces) {
        var old = s.AsSpan();
        var newSpan = new Span<char>(new char[s.Length + spaces.Length]);
        var span = newSpan;
        int pre = 0;
        foreach(var space in spaces) {
            var len = space - pre;
            old[..len].CopyTo(span);
            span[len] = ' ';
            old = old[len..];
            span = span[(len + 1)..];
            pre = space;
        }
        
        old.CopyTo(span);

        return new string(newSpan);
    }
}
