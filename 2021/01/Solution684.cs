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
                int rootU = Find(edge[0]);
                int rootV = Find(edge[1]);
                    
                if(rootU == rootV)
                    return edge;
                

                parent[rootV] = rootU;
            }

            return new int[]{};
        }
    }
}