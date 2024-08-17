using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 551
/// title: 学生出勤记录 I
/// problems: https://leetcode-cn.com/problems/student-attendance-record-i/
/// date: 20240818
/// </summary>
public static partial class Solution551
{
    public static bool CheckRecord(string s) {
        int ACount = 0;
        int LCount = 0;
        foreach(var c in s){
            if (c == 'A') {
                ACount++;
                if (ACount >= 2)
                    return false;
                LCount = 0; // Reset LCount when 'A' is found
            } else if (c == 'L') {
                LCount++;
                if (LCount >= 3)
                    return false;
            } else {
                LCount = 0; // Reset LCount for any other character
            }
        }

        return true;
    }
}
