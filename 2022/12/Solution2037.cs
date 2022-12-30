using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2037
    /// title: 使每位学生都有座位的最少移动次数
    /// problems: https://leetcode.cn/problems/minimum-number-of-moves-to-seat-everyone/
    /// date: 20221231
    /// </summary>
    public static class Solution2037
    {
        public static int MinMovesToSeat(int[] seats, int[] students) {
            Array.Sort(seats);
            Array.Sort(students);
            
            return Enumerable.Range(0, seats.Length)
                            .Sum(i => Math.Abs(seats[i] - students[i]));
        }
    }
}