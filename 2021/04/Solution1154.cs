using System.Globalization;
using System.Runtime.Serialization;
using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 1154
    /// title: 一年中的第几天
    /// problems: https://leetcode-cn.com/problems/day-of-the-year/
    /// date: 20210420
    /// </summary>
    public static partial class Solution1154
    {
        public static int DayOfYear(string date) {
            int[] days = {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334};
            int year = int.Parse(date.AsSpan(0,4));
            int month = int.Parse(date.AsSpan(5,2));
            int day = int.Parse(date.AsSpan(8,2));


            return day + days[month - 1] + (month > 2 && ((year % 4 == 0 && year % 100 != 0 ) || year % 400 == 0) ? 1 : 0);
        }

    }
}