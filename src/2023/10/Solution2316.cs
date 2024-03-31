using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2316
    /// title: 统计无向图中无法互相到达点对数
    /// problems: https://leetcode.cn/problems/count-unreachable-pairs-of-nodes-in-an-undirected-graph/?envType=daily-question&envId=2023-10-21
    /// date: 20231021
    /// </summary>
    public static class Solution2316
    {
        public static long CountPairs(int n, int[][] edges) {
            var graphs = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
            foreach(var edge in edges){
                (int x, int y) = (edge[0], edge[1]);
                graphs[x].Add(y);
                graphs[y].Add(x);
            }

            var visited = new bool[n];
            int DFS(int x){
                visited[x] = true;
                int count = 1;
                foreach(var y in graphs[x]){
                    if (!visited[y])
                        count += DFS(y);
                }

                return count;
            }

            
            long result = 0;
            for(int i = 0; i < n; i++){
                if (visited[i])
                    continue;
                
                int count = DFS(i);
                result += (long)count * (n - count);
            }

            return result / 2;
        }
    }
}