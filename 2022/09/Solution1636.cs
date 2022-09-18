using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1636
    /// title: 按照频率将数组升序排序
    /// problems: https://leetcode.cn/problems/sort-array-by-increasing-frequency/
    /// date: 20220919
    /// </summary>
    public static class Solution1636
    {
        public static int[] FrequencySort(int[] nums) {
            
            return nums.GroupBy(x => x)
                        .OrderBy(g => g.Count())
                        .ThenByDescending(g => g.Key)
                        .SelectMany(g => g.ToList())
                        .ToArray();
        }
    }
}