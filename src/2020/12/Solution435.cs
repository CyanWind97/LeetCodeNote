using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 435
    /// title: 无重叠区间
    /// problems: https://leetcode-cn.com/problems/non-overlapping-intervals/
    /// date: 20201231
    /// </summary>
    public static class Solution435
    {
        public static int EraseOverlapIntervals(int[][] intervals) {
            int length = intervals.Length;
            if(length == 0)
                return 0;
            intervals = intervals.OrderBy(x => (x[0], x[1]))
                                 .ToArray();
            int remove = 0;
            int[] pre = intervals[0];
            for(int i = 1; i < length; i++){
                if(pre[0] == intervals[i][0])
                    remove++;
                else if(pre[1] <= intervals[i][0])
                    pre = intervals[i];
                else if(pre[1] >= intervals[i][1]){
                    pre = intervals[i];
                    remove++;
                }else{
                    remove++;
                }
            }

            return remove;
        }
        
        // 参考解答 右区间排序更优
        public static int EraseOverlapIntervals_1(int[][] intervals) {
            int length = intervals.Length;
            if(length == 0)
                return 0;

            Array.Sort(intervals, (a,b) => (a[1] - b[1]));
            int remove = 0;
            int end = intervals[0][1];
            for(int i = 1; i < length; i++){
                if(intervals[i][0] >= end)
                    end = intervals[i][1];
                else 
                    remove++;
            }

            return remove;
        }
    }
}