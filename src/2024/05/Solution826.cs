using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 826
/// title: 安排工作以达到最大收益
/// problems: https://leetcode.cn/problems/most-profit-assigning-work/
/// date: 20240517
/// </summary>
public static class Solution826
{
    public static int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        var jobs = difficulty.Zip(profit, (d, p) => (d, p))
                    .OrderBy(j => j.d)
                    .ToArray<(int Difficulty, int Profit)>();
        Array.Sort(worker);

        int result = 0;
        int i = 0;
        int best = 0;

        foreach(var w in worker) {
            while(i < jobs.Length && w >= jobs[i].Difficulty){
                best = Math.Max(best, jobs[i].Profit);
                i++;
            }

            result += best;
        }

        return result;
    }
}
