using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2611
    /// title: 老鼠和奶酪
    /// problems: https://leetcode.cn/problems/mice-and-cheese/
    /// date: 20230607
    /// </summary>
    public static class Solution2611
    {
        public static int MiceAndCheese(int[] reward1, int[] reward2, int k) {
            int n = reward1.Length;
            var sum1 = Enumerable.Range(0,n)
                        .Select(i => reward1[i] - reward2[i])
                        .OrderByDescending(x => x)
                        .Take(k)
                        .Sum();
            
            return sum1 + reward2.Sum();
        }
    }
}