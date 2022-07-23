using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1184
    /// title: 公交站间的距离
    /// problems: https://leetcode.cn/problems/distance-between-bus-stops/
    /// date: 20220724
    /// </summary>
    public static class Solution1184
    {
        public static int DistanceBetweenBusStops(int[] distance, int start, int destination) {
            int n = distance.Length;
            int l = (destination - start + n) % n;
            int d1 = Enumerable.Range(0, l)
                        .Sum(i => distance[(i + start) % n]);
            int d2 = Enumerable.Range(0, n - l)
                        .Sum(i => distance[(i + destination) % n]);
            
            return Math.Min(d1, d2);
        }
    }
}