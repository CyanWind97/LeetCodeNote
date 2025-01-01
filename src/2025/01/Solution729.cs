using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 729
/// title: 我的日程安排表 I
/// problems: https://leetcode.cn/problems/my-calendar-i/
/// date: 20250102
/// </summary>
public static partial class Solution729
{
    public class MyCalendar {
        
        private List<(int Start, int End)> _booked = [];
        private IComparer<(int Start, int End)> _comparer 
            = Comparer<(int Start, int End)>.Create((a, b) => a.Start - b.Start);

        public MyCalendar() {
        }
        
        public bool Book(int start, int end) {
            var index = _booked.BinarySearch((start, end), _comparer);
            if (index < 0)
                index = ~index;
            
            if(index > 0 && _booked[index - 1].End > start
            || index < _booked.Count && _booked[index].Start < end)
                return false;
            
            _booked.Insert(index, (start, end));
            return true;
        }
    }
}
