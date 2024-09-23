using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2207
/// title: 字符串中最多数目的子序列
/// problems: https://leetcode.cn/problems/maximize-number-of-subsequences-in-a-string
/// date: 20240924
/// </summary>
public static class Solution2207
{
    public static long MaximumSubsequenceCount(string text, string pattern) {
        var c1 = pattern[0];
        var c2 = pattern[1];
        var count1 = 0L;
        var count2 = 0L;

        var result = 0L;
        foreach(var c in text){
            if(c == c2){
                result += count1;
                count2++;
            }
            
            if(c == c1)
                count1++;
            
        }

        return result += Math.Max(count1, count2);
    }
}
