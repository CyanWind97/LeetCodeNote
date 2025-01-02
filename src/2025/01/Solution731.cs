using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 731
/// title: 我的日程安排表  II
/// problems: https://leetcode.cn/problems/my-calendar-ii/
/// date: 20250103
/// </summary>
public static partial class Solution731
{
    public class MyCalendarTwo {
        List<(int Start, int End)> booked;
        List<(int Start, int End)> overlaps;

        public MyCalendarTwo() {
            booked = new ();
            overlaps = new ();
        }

        public bool Book(int start, int end) {
            foreach (var overlap in overlaps) {
                (int l, int r) = overlap;
                if (l < end && start < r) 
                    return false;
            }
            foreach (var book in booked) {
                (int l, int r) = book;
                if (l < end && start < r) 
                    overlaps.Add((Math.Max(l, start), Math.Min(r, end)));
            }

            booked.Add((start, end));
            return true;
        }
    }
}
