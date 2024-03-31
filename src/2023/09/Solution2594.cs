using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2594
    /// title: 修车的最少时间
    /// problems: https://leetcode.cn/problems/minimum-time-to-repair-cars/?envType=daily-question&envId=2023-09-07
    /// date: 20230907
    /// </summary>
    public static class Solution2594
    {

        // 参考解答
        // 二分
        public static long RepairCars(int[] ranks, int cars) {
            (long l, long r) = (1,  (long)ranks[0] * cars * cars);

            bool Check(long time)
                => ranks.Sum(rank => (long)Math.Sqrt(time / rank)) >= cars;

            while(l < r){
                long mid = (l + r) / 2;
                if(Check(mid))
                    r = mid;
                else
                    l = mid + 1;
            }

            return l;
        }
    }
}