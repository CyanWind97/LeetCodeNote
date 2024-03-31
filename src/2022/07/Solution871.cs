using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 871
    /// title: 最低加油次数
    /// problems: https://leetcode.cn/problems/minimum-number-of-refueling-stops/
    /// date: 20220702
    /// </summary>
    public static class Solution871
    {
        // 参考解答 dp
        public static int MinRefuelStops(int target, int startFuel, int[][] stations) {
            int length = stations.Length;
            var dp = new long[length + 1];
            dp[0] = startFuel;
            for(int i = 0; i < length; i++){
                for(int j = i; j >= 0; j--){
                    if(dp[j] >= stations[i][0])
                        dp[j + 1] = Math.Max(dp[j + 1], dp[j] + stations[i][1]);
                }
            }

            for(int i = 0; i <= length; i++){
                if(dp[i] >= target)
                    return i;
            }

            return -1;
        }

        // 参考解答 贪心
        public static int MinRefuelStops_1(int target, int startFuel, int[][] stations) {
            int length = stations.Length;
            var queue = new PriorityQueue<int, int>();
            int result = 0, pre = 0, fuel = startFuel;

            for(int i = 0; i <= length; i++){
                int cur = i < length ? stations[i][0] : target;
                fuel -= cur - pre;
                while(fuel < 0 && queue.Count > 0){
                    fuel += queue.Dequeue();
                    result++;
                }

                if(fuel < 0)
                    return -1;
                
                if(i < length){
                    queue.Enqueue(stations[i][1], -stations[i][1]);
                    pre = cur;
                }
            }

            return result;
        }
    }
}