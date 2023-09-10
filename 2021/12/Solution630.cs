using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 630
    /// title:  课程表 III
    /// problems: https://leetcode-cn.com/problems/course-schedule-iii/
    /// date: 20211214
    /// </summary>
    public static partial class Solution630
    {
        public static int ScheduleCourse(int[][] courses) {
            Array.Sort(courses, (a, b) => a[1] - b[1]);

            var result = new List<int>();

            int total = 0;;

            foreach(var course in courses){
                int t = course[0];
                int d = course[1];

                bool flag =  false;

                if (total + t <= d){
                    total += t;
                    flag = true;
                }else if(result.Count > 0 && result.Last() > t){
                    var last = result.Last();
                    total -= last - t;
                    result.Remove(last);
                    flag = true;
                }

                if(flag){
                    int index = result.BinarySearch(t);
                    if(index < 0)
                        index = ~index;

                    result.Insert(index, t);
                }
            }

            return result.Count;
        }
    }
}