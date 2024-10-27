using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 685
/// title: 冗余连接 II
/// problems: https://leetcode.cn/problems/redundant-connection-ii
/// date: 20241028
/// </summary>
public static class Solution685
{
    public static int[] FindRedundantDirectedConnection(int[][] edges) {
        int n = edges.Length;
        int[] parent = Enumerable.Range(0, n + 1).ToArray();
        int[] root =  Enumerable.Range(0, n + 1).ToArray();
        int[] candidate1 = null, candidate2 = null;
        int Find(int[] parent, int x) {
            if (parent[x] != x) 
                parent[x] = Find(parent, parent[x]);
            return parent[x];
        }

        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            if (parent[v] != v) {
                candidate1 = [parent[v], v];
                candidate2 = [u, v];
                edge[1] = 0;
            } else {
                parent[v] = u;
            }
        }

        for (int i = 0; i <= n; i++) 
            parent[i] = i;

        foreach (var edge in edges) {
            if (edge[1] == 0) 
                continue;
            
            int u = edge[0], v = edge[1];
            int pu = Find(parent, u);
            if (pu == v) {
                if (candidate1 == null) 
                    return edge;
                
                return candidate1;
            }
            
            parent[v] = pu;
        }
        return candidate2;
    }
}
