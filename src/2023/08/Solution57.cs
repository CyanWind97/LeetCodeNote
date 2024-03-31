using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 57
    /// title: 插入区间
    /// problems: https://leetcode.cn/problems/insert-interval/
    /// date: 20230828
    /// </summary>
    public static class Solution57
    {
        public static int[][] Insert(int[][] intervals, int[] newInterval) {
            int length = intervals.Length;

            if (length == 0)
                return new int[][]{newInterval};
            
            int Search(int target, int start, int index, int offset = 0){
                int left = start;
                int right = length - 1;

                while(left <= right){
                    int mid = left + (right - left) / 2;
                    if (intervals[mid][index] == target)
                        return mid + offset;
                    if(intervals[mid][index] <= target)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }

                return left;
            }

            int start = Search(newInterval[0], start: 0, index: 1, offset: 0);
            int end = Search(newInterval[1], start: start, index: 0, offset: 1);
            var insert = start == end
                        ? newInterval
                        : new int[]{Math.Min(newInterval[0], intervals[start][0]), Math.Max(newInterval[1], intervals[end - 1][1])};

            return intervals[0..start]
                .Append(insert)
                .Concat(intervals[end..length])
                .ToArray();
        }
    }
}