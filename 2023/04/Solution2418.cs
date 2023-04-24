using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2418
    /// title: 按身高排序
    /// problems: https://leetcode.cn/problems/sort-the-people/
    /// date: 20230425
    /// </summary>
    public static class Solution2418
    {
        public static string[] SortPeople(string[] names, int[] heights) {
            return Enumerable.Range(0, names.Length)
                            .OrderByDescending(i => heights[i])
                            .Select(i => names[i])
                            .ToArray();
        }
    }
}