using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2409
    /// title:  统计共同度过的日子数
    /// problems: https://leetcode.cn/problems/count-days-spent-together/
    /// date: 20230417
    /// </summary>

    public static class Solution2409
    {
        public static int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob) {
            var datesOfMonths = new int[12]{31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            var prefixSum = new int[13];
            for (int i = 0; i < 12; i++) {
                prefixSum[i + 1] = prefixSum[i] + datesOfMonths[i];
            }

            int CalculateDayOfYear(string day) {
                int month = int.Parse(day.AsSpan(0, 2));
                int date = int.Parse(day.AsSpan(3));
                return prefixSum[month - 1] + date;
            }

            var startDayA = CalculateDayOfYear(arriveAlice);
            var endDayA = CalculateDayOfYear(leaveAlice);
            var startDayB = CalculateDayOfYear(arriveBob);
            var endDayB = CalculateDayOfYear(leaveBob);

            return Math.Max(0, Math.Min(endDayA, endDayB) - Math.Max(startDayA, startDayB) + 1);
        }
    }
}