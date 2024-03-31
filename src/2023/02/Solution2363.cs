using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2363
    /// title: 合并相似的物品
    /// problems: https://leetcode.cn/problems/merge-similar-items/
    /// date: 20230228
    /// </summary>
    public static class Solution2363
    {
        public static IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2) {
            return items1.Union(items2)
                        .GroupBy(item => item[0])
                        .Select(g => new int[]{g.Key, g.Sum(item => item[1])})
                        .OrderBy(item => item[0])
                        .ToList<IList<int>>();
        }   
    }
}