using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1154
    /// title: 一年中的第几天
    /// problems: https://leetcode-cn.com/problems/day-of-the-year/
    /// date: 20231231
    /// </summary>
    public static partial class Solution1154
    {
        public static int DayOfYear_1(string date) {
            return DateTime.Parse(date).DayOfYear;
        }
    }
}