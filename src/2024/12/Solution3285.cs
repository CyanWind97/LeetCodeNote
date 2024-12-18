using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3285
/// title: 找到稳定山的下标
/// problems: https://leetcode.cn/problems/find-indices-of-stable-mountains
/// date: 20241219
/// </summary>
public static class Solution3285
{
    public static IList<int> StableMountains(int[] height, int threshold) {

        return Enumerable.Range(1, height.Length - 1)
            .Where(i => height[i - 1] > threshold)
            .ToList();
    }
}
