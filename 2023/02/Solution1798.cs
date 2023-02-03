using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    // <summary>
    /// no: 1798
    /// title: 你能构造出连续值的最大数目
    /// problems: https://leetcode.cn/problems/maximum-number-of-consecutive-values-you-can-make/
    /// date: 20230204
    /// </summary>
    public static class Solution1798
    {
        public static int GetMaximumConsecutive(int[] coins) {
            int count = 1;
            Array.Sort(coins);
            foreach (int i in coins) {
                if (i > count) 
                    break;
                
                count += i;
            }

            return count;
        }
    }
}