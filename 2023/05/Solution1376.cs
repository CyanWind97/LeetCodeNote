using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1376
    /// title: 通知所有员工所需的时间
    /// problems: https://leetcode.cn/problems/time-needed-to-inform-all-employees/
    /// date: 20230501
    /// </summary>
    public static class Solution1376
    {
        public static int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
            int result = 0;
            var dp = new int[n];
            for(int i = 0; i < n; i++){
                if(dp[i] != 0)
                    continue;

                int time = 0;
                int index = i;
                while(index != -1){
                    if(dp[index] != 0){
                        time += dp[index];
                        break;
                    }
                    time += informTime[index];
                    index = manager[index];
                }
                dp[i] = time;
                result = Math.Max(result, time);
            }

            return result;
        }
    }
}