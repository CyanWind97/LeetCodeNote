using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2652
    /// title: 倍数求和
    /// problems: https://leetcode.cn/problems/sum-multiples/?envType=daily-question&envId=2023-10-17
    /// date: 20231017
    /// </summary>
    public static class Solution2652
    {
        public static int SumOfMultiples(int n) {
            int f(int n, int m)
                => (m + n / m * m) * (n / m) / 2;
            
            return f(n, 3) + f(n, 5) + f(n, 7) 
                - f(n, 3 * 5) - f(n, 3 * 7) - f(n, 5 * 7) 
                + f(n, 3 * 5 * 7);
        }
    }
}