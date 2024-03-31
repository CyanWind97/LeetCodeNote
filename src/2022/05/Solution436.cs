using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 436
    /// title: 寻找右区间
    /// problems: https://leetcode.cn/problems/find-right-interval/
    /// date: 20220520
    /// </summary>
    public static class Solution436
    {
        public static int[] FindRightInterval(int[][] intervals) {
            var map = new Dictionary<int, int>();
            int length = intervals.Length;
            var result = new int[length];

            for(int i = 0; i < length; i++){
                map.Add(intervals[i][0], i);
                result[i] = intervals[i][1];
            }

            var keys = map.Keys.ToArray();
            Array.Sort(keys);

            for(int i = 0; i < length; i++){
                var index = Array.BinarySearch(keys, result[i]);
                if(index < 0)
                    index = ~index;
                
                result[i] = index == length ? -1 : map[keys[index]];
            }

            return result;
        }
    }
}