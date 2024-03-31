using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1282
    /// title:  用户分组
    /// problems: https://leetcode.cn/problems/group-the-people-given-the-group-size-they-belong-to/
    /// date: 20220812
    /// </summary>
    public static class Solution1282
    {
        public static IList<IList<int>> GroupThePeople(int[] groupSizes) {
            var groups = groupSizes.Select((size, index) => (size, index))
                                .GroupBy(p => p.size)
                                .ToDictionary(g => g.Key, g => g.Select(x => x.index).ToList());

            var result = new List<IList<int>>();

            foreach(var group in groups){
                int size = group.Key;
                var indexs = group.Value;
                for(int i = 0; i <indexs.Count; i += size){
                    result.Add(indexs.GetRange(i, size));
                }
            }

            return result;
        }
    }
}