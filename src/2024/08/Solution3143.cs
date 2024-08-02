using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3143
/// title: 正方形中的最多点数
/// problems: https://leetcode.cn/problems/maximum-points-inside-the-square
/// date: 20240803
/// </summary>
public static class Solution3143
{
    public static int MaxPointsInsideSquare(int[][] points, string s) {
        int n = s.Length;
        var infos = Enumerable.Range(0, n)
                     .Select(i => (Tag : s[i], R: Math.Max(Math.Abs(points[i][0]), Math.Abs(points[i][1]))))
                     .GroupBy(x => x.R)
                     .OrderBy(g => g.Key)
                     .ToDictionary(g => g.Key, g => g.Select(x => x.Tag).ToArray());
        var existedTag = new HashSet<char>();
        var result = 0;

        foreach (var (r, tags) in infos){
            int count = 0;
            foreach (var tag in tags){
                if (existedTag.Contains(tag))
                    return result;
                
                existedTag.Add(tag);
                count++;
            }

            result += count;
        }

        return result;
    }
}
