using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 70
    /// title: 爬楼梯
    /// problems: https://leetcode.cn/problems/climbing-stairs/description/?envType=daily-question&envId=2023-12-10
    /// date: 20231210
    /// </summary>
    public static class Solution70
    {
        public static int ClimbStairs(int n) {
            int a = 1;
            int b = 1;

            for(int i = 2; i <= n; i++){
                (a, b) = (b, a + b);
            }

            return b;
        }
    }
}