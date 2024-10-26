using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 684
/// title: 冗余连接
/// problems: https://leetcode.cn/problems/redundant-connection
/// date: 20241027
/// </summary>
public static partial class Solution684
{
    public static int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        int[] parent = Enumerable.Range(0, n + 1).ToArray();
        int Find(int x) => x == parent[x] ? x : (parent[x] = Find(parent[x]));

        for (int i = 0; i < n; i++) {
            int x = Find(edges[i][0]);
            int y = Find(edges[i][1]);
            if (x == y)
                return edges[i];
            
            parent[x] = y;
        }

        return Array.Empty<int>();
    }
}
