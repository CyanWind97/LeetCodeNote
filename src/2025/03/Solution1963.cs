using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1963
/// title: 使字符串平衡的最小交换次数
/// problems: https://leetcode.cn/problems/minimum-number-of-swaps-to-make-the-string-balanced
/// date: 20250317
/// </summary>
public static class Solution1963
{
    public static int MinSwaps(string s) {
        int unmatchedClosing = 0;  // 记录未匹配的右括号数量
        int maxUnmatchedClosing = 0;  // 记录任意时刻最大的未匹配右括号数量
        
        foreach (char c in s) {
            if (c == '[') {
                unmatchedClosing--;  // 左括号可以匹配一个未匹配的右括号
            } else { // c == ']'
                unmatchedClosing++;  // 增加一个未匹配的右括号
            }
            
            // 更新任意时刻的最大未匹配右括号数量
            maxUnmatchedClosing = Math.Max(maxUnmatchedClosing, unmatchedClosing);
        }
        
        // 交换次数等于 (最大未匹配右括号数量 + 1) / 2 向下取整
        return (maxUnmatchedClosing + 1) / 2;
    }
}
