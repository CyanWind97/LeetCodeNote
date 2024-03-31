using System;
using System.Collections.Generic;

namespace  LeetCodeNote
{
    /// <summary>
    /// no: 757
    /// title: 设置交集大小至少为2
    /// problems: https://leetcode.cn/problems/set-intersection-size-at-least-two/
    /// date: 20220722
    /// </summary>
    public static class Solution757
    {
        // 参考解答 贪心
        public static int IntersectionSizeTwo(int[][] intervals) {
            int length = intervals.Length;
            int result = 0;
            int m = 2;
            Array.Sort(intervals, (a, b) => {
                if (a[0] == b[0]) {
                    return b[1] - a[1];
                }
                return a[0] - b[0];
            });
            var temp = new IList<int>[length];
            for (int i = 0; i < length; i++) {
                temp[i] = new List<int>();
            }

            void Help(int pos, int num) {
                for (int i = pos; i >= 0; i--) {
                    if (intervals[i][1] < num) {
                        break;
                    }
                    temp[i].Add(num);
                }
            }


            for (int i = length - 1; i >= 0; i--) {
                for (int j = intervals[i][0], k = temp[i].Count; k < m; j++, k++) {
                    result++;
                    Help(i - 1, j);
                }
            }
            
            return result;
        }
    }
}