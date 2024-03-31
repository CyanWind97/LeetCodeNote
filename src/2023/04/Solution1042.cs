using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1042
    /// title: 不邻接植花
    /// problems: https://leetcode.cn/problems/flower-planting-with-no-adjacent/
    /// date: 20230415
    /// </summary>
    public static class Solution1042
    {
        public static int[] GardenNoAdj(int n, int[][] paths) {
            var adj = Enumerable.Range(0, n)
                            .Select(x => new List<int>())
                            .ToArray();
            foreach(var path in paths){
                (int x, int y) = (path[0] - 1, path[1] - 1);
                adj[x].Add(y);
                adj[y].Add(x);
            }
            
            var result = new int[n];
            var colored = new bool[5];
            for(int i = 0; i < n; i++){
                Array.Fill(colored, false);
                adj[i].ForEach(v => colored[result[v]] = true);
                result[i] = Enumerable.Range(1, 4).First(j => !colored[j]);
            }

            return result;
        }       
    }
}