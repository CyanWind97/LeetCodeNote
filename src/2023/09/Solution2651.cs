using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2651
    /// title: 计算列车到站时间
    /// problems: https://leetcode.cn/problems/calculate-delayed-arrival-time/?envType=daily-question&envId=2023-09-08
    /// date: 20230908
    /// </summary>
    public static class Solution2651
    {
        public static int FindDelayedArrivalTime(int arrivalTime, int delayedTime) {
            return (arrivalTime + delayedTime) % 24;
        }
    }
}