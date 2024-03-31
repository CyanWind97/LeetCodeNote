using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2129
/// title: 将标题首字母大写
/// problems: https://leetcode.cn/problems/capitalize-the-title/description/?envType=daily-question&envId=2024-03-11
/// date: 20240311
/// </summary>
public static class Solution2129
{
    public static string CapitalizeTitle(string title) {
        return string.Join(" ", title.Split(' ')
                                    .Select(word => word.Length <= 2
                                        ? word.ToLower()
                                        : $"{char.ToUpper(word[0])}{word[1..].ToLower()}" ));
    }
}
