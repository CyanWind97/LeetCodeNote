using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2355
    /// title: 装满杯子需要的最短总时长
    /// problems: https://leetcode.cn/problems/minimum-amount-of-time-to-fill-cups/
    /// date: 20230211
    /// </summary>
    public static class Solution2355
    {
        public static int FillCups(int[] amount) {
            Array.Sort(amount);

            return amount[2] > amount[1] + amount[0]
                ? amount[2]
                : (amount[0] + amount[1] + amount[2] + 1) / 2;
        }
    }
}