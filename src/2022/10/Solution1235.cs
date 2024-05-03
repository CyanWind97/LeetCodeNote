using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1234
    /// title:  规划兼职工作
    /// problems: https://leetcode.cn/problems/maximum-profit-in-job-scheduling/
    /// date: 20221022
    /// </summary>
    public static partial class Solution1235
    {
        public static int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
            int length = startTime.Length;
            var jobs = Enumerable.Range(0, length)
                                .Select(i => (startTime[i], endTime[i], profit[i]))
                                .ToArray<(int StartTime, int EndTime, int Profit)>();
            
            
            Array.Sort(jobs, (a, b) => a.EndTime - b.EndTime);
            int BinarySearch(int right, int time){
                int left = 0;
                while(left < right){
                    int mid = left + (right - left) / 2;
                    if(jobs[mid].EndTime > time)
                        right = mid;
                    else
                        left = mid + 1;
                }

                return left;
            }

            var dp = new int[length + 1];
            for(int i = 1; i <= length; i++){
                int k = BinarySearch(i - 1, jobs[i - 1].StartTime);
                dp[i] = Math.Max(dp[i - 1], dp[k] + jobs[i - 1].Profit);
            }

            return dp[length];
        }
    }
}