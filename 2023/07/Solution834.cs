using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 834
    /// title:  树中距离之和
    /// problems: https://leetcode.cn/problems/sum-of-distances-in-tree/
    /// date: 20230716
    /// </summary>
    public static class Solution834
    {
        // 参考解答
        public static int[] SumOfDistancesInTree(int n, int[][] edges) {
            var result = new int[n];
            var count = new int[n];
            var dp = new int[n];
            var graph = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

            foreach(var edge in edges){
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            void Dfs1(int node, int parent){
                count[node] = 1;
                dp[node] = 0;

                foreach(var child in graph[node]){
                    if(child == parent)
                        continue;
                    
                    Dfs1(child, node);
                    dp[node] += dp[child] + count[child];
                    count[node] += count[child];
                    
                }
            }

            void Dfs2(int node, int parent){
                result[node] = dp[node];
                foreach(var child in graph[node]){
                    if(child == parent)
                        continue;
                    
                    (var pNode, var pChild, var cNode, var cChild) = (dp[node], dp[child], count[node], count[child]);

                    dp[node] -= dp[child] + count[child];
                    count[node] -= count[child];
                    dp[child] += dp[node] + count[node];
                    count[child] += count[node];

                    Dfs2(child, node);
                    
                    (dp[node], dp[child], count[node], count[child]) = (pNode, pChild, cNode, cChild);
                }
            }

            Dfs1(0, -1);
            Dfs2(0, -1);

            return result;
        }
    }
}