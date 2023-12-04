using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2477
    /// title: 到达首都的最少油耗
    /// problems: https://leetcode.cn/problems/minimum-fuel-cost-to-report-to-the-capital/description/?envType=daily-question&envId=2023-12-05
    /// date: 20231205
    /// </summary>

    public static class Solution2477
    {
        public static long MinimumFuelCost(int[][] roads, int seats) {
            int n = roads.Length;
            var g = Enumerable.Range(0, n + 1)
                        .Select(_ => new List<int>())
                        .ToArray();
            
            foreach(var road in roads){
                (int x, int y) = (road[0], road[1]);
                g[x].Add(y);
                g[y].Add(x);
            }

            long result = 0;

            int DFS(int cur, int fa){
                int sum = 1;
                foreach(var next in g[cur]){
                    if(next == fa)
                        continue;
                    
                    int count = DFS(next, cur);
                    sum += count;
                    result += (count + seats - 1) / seats;
                }

                return sum;
            }

            DFS(0, -1);

            return result;
        }
    }
}