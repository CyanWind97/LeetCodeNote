using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 12
    /// title: 整数转罗马数字
    /// problems: https://leetcode-cn.com/problems/integer-to-roman/
    /// date: 20210514
    /// </summary>
    public static class Solution12
    {
        // 1 I 5 V 10 X 50 L 100 C 500 D 1000 M
        // 4 IV 9 IX 40 XL 90 XC 400 CD 900 CM
        public static string IntToRoman(int num) {
            string[] digits = {"","I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};
            string[] tens = {"","X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"};
            string[] hundreds = {"","C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};
            string[] thounds = {"", "M", "MM", "MMM"};

            StringBuilder roman = new StringBuilder();
            roman.Append(thounds[num / 1000]);
            roman.Append(hundreds[(num / 100) % 10]);
            roman.Append(tens[(num / 10) % 10]);
            roman.Append(digits[num % 10]);

            return roman.ToString();
        }
    }
}