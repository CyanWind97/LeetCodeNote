using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2116
/// title:  判断一个括号字符串是否有效
/// problems: https://leetcode.cn/problems/check-if-a-parentheses-string-can-be-valid
/// date: 20250323
/// </summary>
public static class Solution2116
{
    public static bool CanBeValid(string s, string locked) {
        // 长度检查
        if (s.Length % 2 != 0) {
            return false;
        }
        
        int n = s.Length;
        
        // 从左到右扫描，检查是否有足够的右括号
        int balance = 0;
        for (int i = 0; i < n; i++) {
            if (locked[i] == '0' || s[i] == '(') {
                // 可以变成左括号或已经是左括号
                balance++;
            } else {
                // 锁定的右括号
                balance--;
            }
            
            // 右括号过多，无法平衡
            if (balance < 0) {
                return false;
            }
        }
        
        // 从右到左扫描，检查是否有足够的左括号
        balance = 0;
        for (int i = n - 1; i >= 0; i--) {
            if (locked[i] == '0' || s[i] == ')') {
                // 可以变成右括号或已经是右括号
                balance++;
            } else {
                // 锁定的左括号
                balance--;
            }
            
            // 左括号过多，无法平衡
            if (balance < 0) {
                return false;
            }
        }
        
        return true;
    }
}
