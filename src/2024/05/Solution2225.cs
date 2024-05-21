using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2225
/// title: 找出输掉零场或一场比赛的玩家
/// problems: https://leetcode.cn/problems/find-players-with-zero-or-one-losses
/// date: 20240522
/// </summary>
public static class Solution2225
{
    public static IList<IList<int>> FindWinners(int[][] matches) {
        var losers = new SortedDictionary<int, int>();
        var winners = new SortedSet<int>();
        foreach (var match in matches) {
            (int winner, int loser) = (match[0], match[1]);
            if (!losers.ContainsKey(loser)) 
                losers[loser] = 0;
            
            losers[loser]++;
            winners.Remove(loser);

            if (!losers.ContainsKey(winner)) 
                winners.Add(winner);
        }

        return [[.. winners],
                losers.Where(pair => pair.Value <= 1).Select(pair => pair.Key).ToList()];
    }
}
