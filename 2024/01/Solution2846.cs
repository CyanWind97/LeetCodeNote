using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2846
    /// title: 边权重均等查询
    /// problems: https://leetcode.cn/problems/minimum-edge-weight-equilibrium-queries-in-a-tree/description/?envType=daily-question&envId=2024-01-26
    /// date: 20240126
    /// </summary>
    public static class Solution2846
    {
        // 参考解答
        // 最近公共祖先
        public static int[] MinOperationsQueries(int n, int[][] edges, int[][] queries) {
            int length = queries.Length;
            var neighbors =  Enumerable.Range(0, n)
                            .Select(i => new Dictionary<int, int>())
                            .ToArray();
            
            foreach(var edge in edges){
                neighbors[edge[0]][edge[1]] = edge[2];
                neighbors[edge[1]][edge[0]] = edge[2];
            }

            var queryArr = Enumerable.Range(0, n)
                            .Select(i => new List<(int Node, int Index)>())
                            .ToArray();

            for(int i = 0; i < length; i++){
                queryArr[queries[i][0]].Add((queries[i][1], i));
                queryArr[queries[i][1]].Add((queries[i][0], i));
            }
            
            var count = new int[n][];
            for(int i = 0; i < n; i++){
                count[i] = new int[27];
            }   

            var visited = new bool[n];
            var uf = new int[n];
            var lca = new int[length];

            void Tarjan(int node, int parent) {
                if (parent != -1){
                    Array.Copy(count[parent], count[node], 27);
                    count[node][neighbors[node][parent]]++;
                }

                uf[node] = node;

                foreach(var child in neighbors[node].Keys){
                    if (child == parent)
                        continue;
                    
                    Tarjan(child, node);
                    uf[child] = node;
                }

                foreach(var query in queryArr[node]){
                    if (node != query.Node && !visited[query.Node])
                        continue;
                    
                    lca[query.Index] = Find(query.Node);
                }

                visited[node] = true;
            }

            int Find(int x) => x == uf[x] ? x : uf[x] = Find(uf[x]);

            Tarjan(0, -1);
            var result = new int[length];

            for(int i = 0; i < length; i++){
                int totalCount = 0;
                int maxCount = 0;
                for(int j = 1; j <= 26; j++){
                    int t = count[queries[i][0]][j] + count[queries[i][1]][j] - 2 * count[lca[i]][j];
                    maxCount = Math.Max(maxCount, t);
                    totalCount += t;
                }

                result[i] = totalCount - maxCount;
            }

            return result;
        }
    }
}