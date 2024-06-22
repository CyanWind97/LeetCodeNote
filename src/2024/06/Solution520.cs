using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 520
/// title: 检测大写字母
/// problems: https://leetcode-cn.com/problems/detect-capital/
/// date: 20240623
/// </summary>
public static partial class Solution520
{
    public static bool DetectCapitalUse(string word) {
        int length = word.Length;
        bool isFirst = char.IsUpper(word[0]);
        int count = isFirst ? 1 : 0;

        count += word.Skip(1).Count(char.IsUpper);
        
        return count == length || count == 0 || (count == 1 && isFirst);
    }
}
