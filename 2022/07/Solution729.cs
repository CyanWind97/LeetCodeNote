using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 729
    /// title: 我的日程安排表 I
    /// problems: https://leetcode.cn/problems/my-calendar-i/
    /// date: 202200705
    /// </summary>
    public static class Solution729
    {
        public class MyCalendar {
            
            private List<(int Start, int End)> _booked;

            public MyCalendar() {
                _booked = new();
            }
            
            public bool Book(int start, int end) {
                if(_booked.Any(b => b.Start < end && start < b.End))
                    return false;
                
                _booked.Add((start, end));
                return true;
            }
        }
    }
}