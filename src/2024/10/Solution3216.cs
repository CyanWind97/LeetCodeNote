using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3216
/// title: 交换后字典序最小的字符串
/// problems: https://leetcode.cn/problems/lexicographically-smallest-string-after-a-swap
/// date: 20241030
/// </summary>
public static class Solution3216
{
    public static string GetSmallestString(string s) {
        char[] arr = s.ToCharArray();
        for (int i = 0; i + 1 < arr.Length; i++) {
            if (arr[i] > arr[i + 1] && arr[i] % 2 == arr[i + 1] % 2) {
                (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                break;
            }
        }
        
        return new string(arr);
    }
}
