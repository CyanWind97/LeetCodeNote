using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2646
    /// title: 最小化旅行的价格总和
    /// problems: https://leetcode.cn/problems/minimize-the-total-price-of-the-trips/description/?envType=daily-question&envId=2023-12-06
    /// date: 20231206
    /// </summary>
    public static class Solution2646
    {
        // 参考解答
        // 深度优先搜索 + dp
        public static int MinimumTotalPrice(int n, int[][] edges, int[] price, int[][] trips) {
            var g = Enumerable.Range(0, n)
                        .Select(_ => new List<int>())
                        .ToArray();
            
            foreach(var edge in edges){
                (int x, int y) = (edge[0], edge[1]);
                g[x].Add(y);
                g[y].Add(x);
            }

            var count = new int[n];
            bool DFS(int node, int parent, int end){
                if (node == end){
                    count[node]++;
                    return true;
                }

                foreach(var next in g[node]){
                    if(next == parent)
                        continue;
                    
                    if(DFS(next, node, end)){
                        count[node]++;
                        return true;
                    }
                }

                return false;
            }

            foreach(var trip in trips){
                DFS(trip[0], -1,  trip[1]);
            }


            (int , int) DP(int node, int parent){
                var r1 = price[node] * count[node];
                var r2 = r1 / 2;
            
                foreach(var next in g[node]){
                    if(next == parent)
                        continue;
                    
                    var (nr1, nr2) = DP(next, node);
                    r1 += Math.Min(nr1, nr2);
                    r2 += nr1;
                }

                return (r1, r2);
            }

            var (r1, r2) = DP(0, -1);

            return Math.Min(r1, r2);
        }
    }
}