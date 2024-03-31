using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2171
    /// title: 拿出最少数目的魔法豆
    /// problems: https://leetcode.cn/problems/removing-minimum-number-of-magic-beans/description/?envType=daily-question&envId=2024-01-18
    /// date: 20240118
    /// </summary>
    public static class Solution2171
    {
        public static long MinimumRemoval(int[] beans) {
            Array.Sort(beans);

            int length = beans.Length;

            var sum = beans.Sum(x =>(long)x);
            var result = sum;

            return Enumerable.Range(0, length)
                .Select(i => sum - (long)(length - i) * beans[i])
                .Min();
        }
    }
}