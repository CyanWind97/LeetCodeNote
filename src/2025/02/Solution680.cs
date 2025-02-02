using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 680
/// title: 验证回文串 II
/// problems: https://leetcode.cn/problems/valid-palindrome-ii
/// date: 20250203
/// </summary>
public static class Solution680
{
    public static bool ValidPalindrome(string s) {
        bool IsPalindrome(int left, int right) {
            while (left < right) {
                if (s[left] != s[right]) {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        int left = 0, right = s.Length - 1;
    
        while (left < right) {
            if (s[left] != s[right]) {
                // 尝试跳过左边或右边的字符
                return IsPalindrome(left + 1, right) 
                    || IsPalindrome(left, right - 1);
            }
            left++;
            right--;
        }
        
        return true;
    }
}
