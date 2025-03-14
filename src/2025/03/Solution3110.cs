using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3110
/// title: 字符串的分数
/// problems: https://leetcode.cn/problems/score-of-a-string
/// date: 20250315
/// </summary>
public static class Solution3110
{
    public static int ScoreOfString(string s) {
        if (string.IsNullOrEmpty(s) || s.Length == 1) {
            return 0; // 空字符串或只有一个字符时，分数为0
        }
        
        int score = 0;
        
        // 计算相邻字符ASCII码差值绝对值的和
        for (int i = 0; i < s.Length - 1; i++) {
            int diff = Math.Abs(s[i] - s[i + 1]);
            score += diff;
        }
        
        return score;
    }
}
