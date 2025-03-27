using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2716
/// title:  最小化字符串长度
/// problems: https://leetcode.cn/problems/minimize-string-length
/// date: 20250328
/// </summary>
public static class Solution2716
{
    public static int MinimizedStringLength(string s) {
        HashSet<char> uniqueChars = [.. s];
        
        return uniqueChars.Count;
    }
}
