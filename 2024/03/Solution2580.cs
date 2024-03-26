using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2580
/// title: 统计将重叠区间合并成组的方案数
/// problems: https://leetcode.cn/problems/count-ways-to-group-overlapping-ranges
/// date: 20240327
/// </summary>
public static class Solution2580
{
    public static int CountWays(int[][] ranges) {
        int mod = 1000000007;
        
        int n = ranges.Length;
        Array.Sort(ranges, (a, b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);
        var merged = new List<(int Start, int End)>();

        for(int i = 0; i < n; i++) {
            if(merged.Count == 0 || merged[^1].End < ranges[i][0]) 
                merged.Add((ranges[i][0], ranges[i][1]));
            else 
                merged[^1] = (merged[^1].Start, Math.Max(merged[^1].End, ranges[i][1]));
        }

        int m = merged.Count;
        // 2^m % mod
        int Pow(int y) {
            long res = 1;
            for(int i = 0; i < y; i++) {
                res = (res * 2) % mod;
            }
            return (int)res;
        }

        return Pow(m);
    }
}
