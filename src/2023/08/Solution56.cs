using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 56
    /// title: 合并区间
    /// problems: https://leetcode.cn/problems/merge-intervals/
    /// date: 20230827
    /// </summary>
    public static class Solution20230827
    {
        public static int[][] Merge(int[][] intervals) {
            var result = new List<int[]>();

            Array.Sort(intervals, (a, b) => a[0] == b[0] 
                                        ? a[1].CompareTo(b[1]) 
                                        : a[0].CompareTo(b[0]));

            int curStart = intervals[0][0];
            int curEnd = intervals[0][1];

            foreach(var interval in intervals){
                if(interval[0] > curEnd){
                    result.Add(new int[]{curStart, curEnd});
                    curStart = interval[0];
                    curEnd = interval[1]; 
                }else if(interval[1] > curEnd){
                    curEnd = interval[1];
                }
            }

            result.Add(new int[]{curStart, curEnd});

            return result.ToArray();
        }
    }
}