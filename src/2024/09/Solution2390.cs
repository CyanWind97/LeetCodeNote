using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2390
/// title: 从字符串中移除星号
/// problems: https://leetcode.cn/problems/removing-stars-from-a-string
/// date: 20240914
/// </summary>
public static class Solution2390
{
    public static string RemoveStars(string s) {
        int n = s.Length;
        var stack = new Stack<char>();
        for(int i = 0; i < n; i++){
            if(s[i] != '*')
                stack.Push(s[i]);
            else if (stack.Count > 0)
                stack.Pop();
        }

        return new string(stack.Reverse().ToArray());
    }
}
