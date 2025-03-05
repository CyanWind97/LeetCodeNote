using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeeCodeNote;

/// <summary>
/// no: 1328
/// title: 破坏回文串
/// problems: https://leetcode.cn/problems/break-a-palindrome
/// date: 20250305
/// </summary>
public static class Solution1328
{
    public static string BreakPalindrome(string palindrome) {
        if (palindrome.Length <= 1) return "";
    
        char[] chars = palindrome.ToCharArray();
        int n = palindrome.Length;
        
        // 从左到右遍历前半部分
        for (int i = 0; i < n/2; i++) {
            // 如果当前字符不是'a'，则将其改为'a'
            if (chars[i] != 'a') {
                chars[i] = 'a';
                return new string(chars);
            }
        }
        
        // 如果前半部分都是'a'，则将最后一个字符改为'b'
        chars[n-1] = 'b';
        return new string(chars);
    }
}
