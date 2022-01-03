using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1185
    /// title: 一周中的第几天
    /// problems: https://leetcode-cn.com/problems/day-of-the-week/
    /// date: 20220103
    /// </summary>
    public static class Solution1185
    {
        public static string DayOfTheWeek(int day, int month, int year) {
            return (new DateTime(year, month, day)).DayOfWeek.ToString();
        }
    }
}