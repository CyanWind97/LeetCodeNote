using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2924
/// title: 找到冠军 II
/// problems: https://leetcode.cn/problems/find-champion-ii
/// date: 20240413
/// </summary>
public static class Solution2924
{
    public static int FindChampion(int n, int[][] edges) {
        var inDegree = new int[n];
        foreach(var edge in edges){
            inDegree[edge[1]]++;
        }

        var options = inDegree.Select((d, i) => (Degree: d, Index: i))
                    .Where(p => p.Degree == 0)
                    .Select(p => p.Index)
                    .ToList();

        return options.Count == 1 ? options[0] : -1;
    }
}
