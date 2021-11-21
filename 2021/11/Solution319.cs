using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 319
    /// title:  灯泡开关
    /// problems: https://leetcode-cn.com/problems/bulb-switcher/
    /// date: 20211115
    /// </summary>
    public static class Solution319
    {
        public static int BulbSwitch(int n) {
            return (int) Math.Sqrt(n + 0.5);
        }
    }
}