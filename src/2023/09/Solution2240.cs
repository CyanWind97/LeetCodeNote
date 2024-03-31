using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2240
    /// title: 买钢笔和铅笔的方案数
    /// problems: https://leetcode.cn/problems/number-of-ways-to-buy-pens-and-pencils/
    /// date: 20230901
    /// </summary>
    public static class Solution2240
    {
        public static long WaysToBuyPensPencils(int total, int cost1, int cost2) {
            if (cost1 < cost2)
                (cost1, cost2) = (cost2, cost1);
            
            long result = 0;
            long count = 0;
            while(count * cost1 <= total){
                result += (total - count * cost1) / cost2 + 1;
                count++;
            }

            return result;
        }
    }
}