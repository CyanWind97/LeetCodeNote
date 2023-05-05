using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2432
    /// title:  处理用时最长的那个任务的员工
    /// problems: https://leetcode.cn/problems/the-employee-that-worked-on-the-longest-task/
    /// date: 20230505
    /// </summary>
    public static class Solution2432
    {
        public static int HardestWorker(int n, int[][] logs) {
            int curId = logs[0][0];
            int maxTime = logs[0][1];
            int preTime = logs[0][1];

            foreach(var log in logs.Skip(1)){
                int time = log[1] - preTime;
                if(time > maxTime){
                    maxTime = time;
                    curId = log[0];
                }else if (time == maxTime){
                    curId = Math.Min(curId, log[0]);
                }

                preTime = log[1];
            }

            return curId;
        }
    }
}