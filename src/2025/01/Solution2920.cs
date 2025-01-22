using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2920
/// title: 收集所有金币可获得的最大积分
/// problems: https://leetcode.cn/problems/maximum-points-after-collecting-coins-from-all-nodes
/// date: 20250123
/// </summary>
public static class Solution2920
{
    public static int MaximumPoints(int[][] edges, int[] coins, int k) {
        int n = coins.Length;
    var graph = new List<int>[n];
    for(int i = 0; i < n; i++)
        graph[i] = new List<int>();
    
    // 建图
    foreach(var edge in edges){
        graph[edge[0]].Add(edge[1]);
        graph[edge[1]].Add(edge[0]);
    }

    // dp[i,j]表示当前节点i在祖先节点被除以2的次数为j时的最大积分
    var dp = new int[n, 14];
    for(int i = 0; i < n; i++)
        for(int j = 0; j < 14; j++)
            dp[i,j] = -1;

    int DFS(int node, int parent, int div){
        // 金币数除以2的次数超过13次后就会变成0，无需继续计算
        if(div >= 14)
            return 0;
        
        if(dp[node,div] != -1)
            return dp[node,div];
        
        // 当前节点的金币数
        int coins1 = coins[node] >> div;
        // 选择方案1：减去k
        int score1 = coins1 - k;
        // 选择方案2：除以2
        int score2 = coins1 >> 1;

        // 遍历子节点
        foreach(var next in graph[node]){
            if(next == parent)
                continue;
            
            score1 += DFS(next, node, div);
            score2 += DFS(next, node, div + 1);
        }

        dp[node,div] = Math.Max(score1, score2);
        return dp[node,div];
    }

    return DFS(0, -1, 0);
    }
}
