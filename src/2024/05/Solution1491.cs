using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

///<summary>
/// no: 1491
/// title: 去掉最低工资和最高工资后的工资平均值
/// problems: https://leetcode.cn/problems/average-salary-excluding-the-minimum-and-maximum-salary/description/?envType=daily-question&envId=2024-05-03
/// date: 20240503
/// </summary>
public static class Solution1491
{
    public static double Average(int[] salary) {
        double min = double.MaxValue;
        double max = double.MinValue;

        double sum = 0;

        foreach(var s in salary){
            sum += s;
            min = Math.Min(min, s);
            max = Math.Max(max, s);
        }

        return (sum - min - max) / (salary.Length - 2);
    }
}
