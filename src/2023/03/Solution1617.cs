using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1617
    /// title: 统计子树中城市之间最大距离
    /// problems: https://leetcode.cn/problems/count-subtrees-with-max-distance-between-cities/
    /// date: 20230312
    /// </summary>
    public static class Solution1617
    {
        // 参考解答
        // 动态规划
        public static int[] CountSubgraphsForEachDiameter(int n, int[][] edges) {
            var adj = Enumerable.Range(0, n).Select(i => new List<int>()).ToArray();
            int mask;
            int diameter;

            foreach(int[] edge in edges) {
                int x = edge[0] - 1;
                int y = edge[1] - 1;
                adj[x].Add(y);
                adj[y].Add(x);
            }

            int DFS(int root) {
                int first = 0, second = 0;
                mask &= ~(1 << root);
                foreach(int vertex in adj[root]) {
                    if ((mask & (1 << vertex)) != 0) {
                        mask &= ~(1 << vertex);
                        int distance = 1 + DFS(vertex);
                        if (distance > first) {
                            second = first;
                            first = distance;
                        } else if (distance > second) {
                            second = distance;
                        }
                    }
                }
                diameter = Math.Max(diameter, first + second);
                return first;
            }

            int NumberOfLeadingZeros(int x){
                if (x == 0) 
                    return 32;
                
                int n = 31;
                if (x >= 1 << 16) { 
                    n -= 16; 
                    x >>= 16; 
                }

                if (x >= 1 << 8) {
                    n -= 8; 
                    x >>= 8; 
                }

                if (x >= 1 << 4) { 
                    n -= 4; 
                    x >>= 4; 
                }

                if (x >= 1 << 2) { 
                    n -= 2; 
                    x >>= 2; 
                }

                return n - (x >> 1);
            }


            var result = new int[n - 1];
            for (int i = 1; i < (1 << n); i++) {
                int root = 32 - NumberOfLeadingZeros(i) - 1;
                mask = i;
                diameter = 0;
                DFS(root);
                if (mask == 0 && diameter > 0) {
                    result[diameter - 1]++;
                }
            }
            
            return result;
        }   
    }
}