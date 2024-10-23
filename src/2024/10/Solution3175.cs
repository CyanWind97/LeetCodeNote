using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3175
/// title: 找到连续赢 K 场比赛的第一位玩家
/// problems: https://leetcode.cn/problems/find-the-first-player-to-win-k-games-in-a-row
/// date: 20241024
/// </summary>
public static class Solution3175
{
    public static int FindWinningPlayer(int[] skills, int k) {
        int n = skills.Length;
        int count = 0;
        int i = 0;
        int last = 0;

        while (i < n){
            int j = i + 1;
            while(j < n && skills[j] < skills[i] && count < k){
                j++;
                count++;
            }

            if (count == k)
                return i;
            
            count = 1;
            last = i;
            i = j;
        }

        return last;
    }
}
