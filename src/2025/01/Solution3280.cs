using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3280
/// title: 将日期转换为二进制表示
/// problems: https://leetcode.cn/problems/convert-date-to-binary
/// date: 20250101
/// </summary>
public static class Solution3280
{
    public static string ConvertDateToBinary(string date) {
        return string.Join('-',
                date.Split('-')
                    .Select(x => Convert.ToString(int.Parse(x), 2)));
    }
}
