using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 983
/// title: 最低票价
/// problems: https://leetcode.cn/problems/minimum-cost-for-tickets
/// date: 20241001
/// </summary>
public static class Solution983
{
    public static int MincostTickets(int[] days, int[] costs) {
        var dp = new int[366];
        var daySet = days.ToHashSet();

        int Calc(int i){
            if(i > 365)
                return 0;
            
            if(dp[i] != 0)
                return dp[i];
            
            if(daySet.Contains(i)){
                dp[i] = Math.Min(Calc(i + 1) + costs[0], 
                                Math.Min(Calc(i + 7) + costs[1], 
                                    Calc(i + 30) + costs[2]));
            }else{
                dp[i] = Calc(i + 1);
            }

            return dp[i];
        }

        return Calc(1);
    }
}
