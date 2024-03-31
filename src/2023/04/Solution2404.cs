using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2404
    /// title: 出现最频繁的偶数元素
    /// problems: https://leetcode.cn/problems/most-frequent-even-element/
    /// date: 20230413
    /// </summary>
    public static class Solution2404
    {
        public static int MostFrequentEven(int[] nums) {
            var temp = nums.Where(num => num % 2 == 0);
            if(!temp.Any())
                return -1;

            return temp.GroupBy(num => num)
                        .OrderBy(g => g.Key)
                        .MaxBy(g => g.Count())
                        .Key;
        }
    }
}