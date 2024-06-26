using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2734
/// title: 执行子串操作后的字典序最小字符串
/// problems: https://leetcode.cn/problems/lexicographically-smallest-string-after-substring-operation
/// date: 20240627
/// </summary>
public static class Solution2734
{
    public static string SmallestString(string s) {
        var span = new Span<char>(s.ToCharArray());
        int length = span.Length;
        int start = 0;
        while(start < length && span[start] == 'a')
            start++;
        
        if (start == length)
        {
            span[^1] = 'z';
            return new string(span);
        }

        int end = start;
        while(end < length && span[end] != 'a')
            end++;

        foreach(ref var c in span[start..end])
            c = (char)(c - 1);
        
        return new string(span);
    }
}
