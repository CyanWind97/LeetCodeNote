using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3159
/// title: 查询数组中元素的出现位置
/// problems: https://leetcode.cn/problems/find-occurrences-of-an-element-in-an-array
/// date: 20241227
/// </summary>
public static class Solution3159
{
    public static int[] OccurrencesOfElement(int[] nums, int[] queries, int x) {
        var indexs = nums.Select((num, index) => (num, index))
                        .Where(t => t.num == x)
                        .Select(t => t.index)
                        .ToArray();
        int count = indexs.Length;

        return queries.Select(q =>  q > count ? -1 : indexs[q - 1]).ToArray();
    }
}
