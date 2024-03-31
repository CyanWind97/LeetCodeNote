using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1615
    /// title: 最大网络秩
    /// problems: https://leetcode.cn/problems/maximal-network-rank/
    /// date: 20230315
    /// </summary>
    public static class Solution1615
    {
        public static int MaximalNetworkRank(int n, int[][] roads) {
            var connect = new bool[n , n];
            var degree = new int[n];
            foreach(var road in roads){
                int x = road[0];
                int y = road[1];
                connect[x, y] = true;
                connect[y, x] = true;
                degree[x]++;
                degree[y]++;
            }

            int maxRank = 0;
            for(int i = 0; i < n; i++){
                for(int j = i + 1; j < n; j++){
                    int rank = degree[i] + degree[j] - (connect[i, j] ? 1 : 0);
                    maxRank = Math.Max(maxRank, rank);
                }
            }

            return maxRank;
        }
    }
}