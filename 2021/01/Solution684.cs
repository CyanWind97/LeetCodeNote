using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 684
    /// title: 冗余连接
    /// problems: https://leetcode-cn.com/problems/redundant-connection/
    /// date: 20210113
    /// </summary>
    public static class Solution684
    {
        public static int[] FindRedundantConnection(int[][] edges) {
            int length = edges.Length + 1;
            int[] parent = new int[length];
            bool[] visited = new bool[length];

            for(int i = 1; i < length; i++){
                parent[i] = i;
            }

            int Find(int x){
                if(x != parent[x]){
                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }

            foreach(var edge in edges){
                int u = edge[0];
                int v = edge[1];

                int rootU = Find(u);
                int rootV = Find(v);
                    
                if(rootU == rootV){
                    if(visited[u] && visited[v])
                        return new int[]{u, v};
                    else
                        continue;
                }

                parent[rootV] = rootU;

                if(!visited[u])
                    visited[u] = true;

                if(!visited[v])
                    visited[v] = true;
            }

            return new int[]{};
        }
    }
}