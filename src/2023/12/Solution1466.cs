using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1466
    /// title: 重新规划路线
    /// problems: https://leetcode.cn/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero/description/?envType=daily-question&envId=2023-12-07
    /// date: 20231207
    /// </summary>
    public static class Solution1466
    {
        public static int MinReorder(int n, int[][] connections) {
            var g = Enumerable.Range(0, n)
                        .Select(_ => new List<(int, int)>())
                        .ToArray();
            
            foreach(var edge in connections){
                (int x, int y) = (edge[0], edge[1]);
                g[x].Add((y, 1));
                g[y].Add((x, 0));
            }

            int DFS(int node, int parent){
                int result = 0;
                foreach(var (next, flag) in g[node]){
                    if(next == parent)
                        continue;
                    
                    result += flag + DFS(next, node);
                }

                return result;
            }

            return DFS(0, -1);
        }
    }
}