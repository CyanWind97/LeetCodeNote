using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2413
    /// title: 最小偶倍数
    /// problems: https://leetcode.cn/problems/smallest-even-multiple/
    /// date: 20230421
    /// </summary>
    public static class Solution2413
    {
        public static int SmallestEvenMultiple(int n) {
            return n % 2 == 0 ? n : 2 * n;
        }
    }
}