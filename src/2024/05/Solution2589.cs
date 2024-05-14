using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2589
/// title: 完成所有任务的最少时间
/// problems: https://leetcode.cn/problems/minimum-time-to-complete-all-tasks
/// date: 20240515
/// </summary>
public class Solution2589
{
    public static int FindMinimumTime(int[][] tasks) {
        int n = tasks.Length;
        Array.Sort(tasks, (a, b) => a[1] - b[1]);
        int[] run = new int[tasks[n - 1][1] + 1];
        int res = 0;
        for (int i = 0; i < n; i++) {
            int start = tasks[i][0], end = tasks[i][1], duration = tasks[i][2];
            for (int j = start; j <= end; j++) {
                duration -= run[j];
            }
            res += Math.Max(duration, 0);
            for (int j = end; j >= 0 && duration > 0; j--) {
                if (run[j] == 0) {
                    duration--;
                    run[j] = 1;
                }
            }
        }
        
        return res;
    }
}
