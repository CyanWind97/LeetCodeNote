using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 855
    /// title: 考场就座
    /// problems: https://leetcode.cn/problems/exam-room/
    /// date: 20221230
    /// </summary>
    public static class Solution855
    {
        // 参考解答
        // 有序集合
        public class ExamRoom {
            private int _n;
            private SortedSet<int> _students;

            
            public ExamRoom(int n) {
                _n = n;
                _students = new SortedSet<int>();
            }
            
            public int Seat() {
                int student = 0;
                if(_students.Count > 0){
                    int dist = _students.Min;
                    int? prev = null;
                    foreach(var s in _students){
                        if(prev.HasValue){
                            int d = (s - prev.Value) / 2;
                            if(d > dist){
                                dist = d;
                                student = prev.Value + d;
                            }
                        }

                        prev = s;
                    }

                    if(_n - 1 - _students.Max > dist)
                        student = _n - 1;
                }

                _students.Add(student);
                return student;
            }
            
            public void Leave(int p) {
                _students.Remove(p);
            }
        }
    }
}