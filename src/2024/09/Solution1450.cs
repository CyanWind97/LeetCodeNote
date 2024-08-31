using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 1450
/// title:  在既定时间做作业的学生人数
/// problems: https://leetcode.cn/problems/number-of-students-doing-homework-at-a-given-time/
/// date: 20240901
/// </summary>
public static partial class Solution1450
{
    
    public static int BusyStudent(int[] startTime, int[] endTime, int queryTime) {
        return Enumerable.Range(0, startTime.Length)
                        .Count(i => startTime[i] <= queryTime && endTime[i] >= queryTime);
    }
}
