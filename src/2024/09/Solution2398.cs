using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2398
/// title:  预算内的最多机器人数目
/// problems: https://leetcode.cn/problems/maximum-number-of-robots-within-budget
/// date: 20240913
/// </summary>
public static class Solution2398
{
    public static int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget) {
        int result = 0;
        int n = chargeTimes.Length;
        long sum = 0;
        var list = new LinkedList<int>();
        for(int r = 0, l = 0; r < n; r++){
            sum += runningCosts[r];
            while(list.Count > 0 
            && chargeTimes[list.Last.Value] <= chargeTimes[r])
                list.RemoveLast();
            
            list.AddLast(r);
            while(l <= r 
            && (r - l + 1) * sum + chargeTimes[list.First.Value] > budget){
                if(list.Count > 0 && list.First.Value == l)
                    list.RemoveFirst();
                
                sum -= runningCosts[l];
                l++;
            }

            result = Math.Max(result, r - l + 1);
        }

        return result;
    }
}
