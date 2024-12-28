using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1366
/// title: 通过投票对团队排名
/// problems: https://leetcode.cn/problems/rank-teams-by-votes
/// date: 20241229
/// </summary>
public static class Solution1366
{
    public static string RankTeams(string[] votes) { 
        int length = votes[0].Length;
        var rank = new Dictionary<char, int[]>();
        // 初始化每个团队的排名统计数组
        foreach (var team in votes[0]) {
            rank[team] = new int[length];
        }

        // 统计每个团队在每个位置上的得票数
        foreach (var vote in votes) {
            for (int i = 0; i < vote.Length; i++) {
                rank[vote[i]][i]++;
            }
        }

        // 排序规则：先按得票数排序，再按字母顺序排序
        var sortedTeams = rank.Keys.ToList();
        sortedTeams.Sort((a, b) => {
            for (int i = 0; i < length; i++) {
                if (rank[a][i] != rank[b][i]) {
                    return rank[b][i] - rank[a][i];
                }
            }
            return a - b;
        });

        return new string([.. sortedTeams]);
    }
}
