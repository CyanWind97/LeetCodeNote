using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2414
/// title: 最长的字母序连续子字符串的长度
/// problems: https://leetcode.cn/problems/length-of-the-longest-alphabetical-continuous-substring
/// date: 20240919
/// </summary>
public static class Solution2414
{
    public static int LongestContinuousSubstring(string s) {
        int result = 1;
        int count = 1;
        for(int i = 1; i < s.Length; i++){
            if(s[i] - s[i - 1] == 1)
                count++;
            else
            {
                result = Math.Max(result, count);
                count = 1;
            }
        }

        return Math.Max(result, count);
    }
}
