using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2575
/// title: 找出字符串的可整除数组
/// problems: https://leetcode.cn/problems/find-the-divisibility-array-of-a-string
/// date: 20240307
/// </summary>
public static class Solution2575
{
    public static int[] DivisibilityArray(string word, int m) {
        int length = word.Length;
        var result = new int[length];
        long mod = 0;
        for(int i = 0; i < length; i++){
            mod = (mod * 10 + word[i] - '0') % m;
            result[i] = mod == 0 ? 1 : 0;
        }

        return result;
    }
}
