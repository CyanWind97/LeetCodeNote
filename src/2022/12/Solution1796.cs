using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1769
    /// title:  字符串中第二大的数字
    /// problems: https://leetcode.cn/problems/second-largest-digit-in-a-string/
    /// date: 20221203
    /// </summary>
    public static class Solution1796
    {
        public static int SecondHighest(string s) {
            int first = -1, second = -1;
            foreach (char c in s) {
                if (char.IsDigit(c)) {
                    int num = c - '0';
                    if (num > first) {
                        second = first;
                        first = num;
                    } else if (num < first && num > second) {
                        second = num;
                    }
                }
            }

            return second;
        }
    }
}