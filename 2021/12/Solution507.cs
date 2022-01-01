using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 507
    /// title:  完美数
    /// problems: https://leetcode-cn.com/problems/perfect-number/
    /// date: 20211231
    /// </summary>
    public static class Solution507
    {
        public static bool CheckPerfectNumber(int num) {
            var perfectNums = new int[]{6, 28, 496, 8128, 33550336};

            return perfectNums.Contains(num);
        }
    }
}