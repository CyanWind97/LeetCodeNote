using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3083
/// title: 字符串及其反转中是否存在同一子字符串
/// problems: https://leetcode.cn/problems/existence-of-a-substring-in-a-string-and-its-reverse
/// date: 20241226
/// </summary>
public static class Solution3083
{
    // 参考解答
    // hash
    public static bool IsSubstringPresent(string s) {
        int length = s.Length;
        var h = new int[26];

        for (int i  = 0; i < length - 1; i++){
            var x = s[i] - 'a';
            var y = s[i + 1] - 'a';
            h[x] |= 1 << y;
            if ((h[y] >> x & 1) != 0)
                return true;
        }

        return false;
    }
}
