using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1326
    /// title: 灌溉花园的最少水龙头数目
    /// problems: https://leetcode.cn/problems/minimum-number-of-taps-to-open-to-water-a-garden/
    /// date: 20230221
    /// </summary>
    public static class Solution1326
    {
        // 参考解答
        // 贪心
        public static int MinTaps(int n, int[] ranges) {
            var rightMost = Enumerable.Range(0, n + 1).ToArray();
            
            for(int i = 0; i <= n; i++){
                int start = Math.Max(0, i - ranges[i]);
                int end = Math.Min(n, i + ranges[i]);
                rightMost[start] = Math.Max(rightMost[start], end);
            }

            int last = 0;
            int prev = 0;
            int result = 0;

            for(int i = 0; i < n; i++){
                last = Math.Max(last, rightMost[i]);
                if(i == last)
                    return -1;
                
                if(i == prev){
                    result++;
                    prev = last;
                }
            }

            return result;
        }
    }
}