using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2481
    /// title: 分割圆的最少切割次数
    /// problems: https://leetcode.cn/problems/minimum-cuts-to-divide-a-circle/
    /// date: 20230617
    /// </summary>
    public static class Solution2481
    {
        public static int NumberOfCuts(int n) {
            return n % 2 == 0 
                ? n / 2 
                : n == 1 ? 0 : n;
        }
    }
}