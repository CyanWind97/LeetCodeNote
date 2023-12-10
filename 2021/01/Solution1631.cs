using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1631
    /// title: 最小体力消耗路径
    /// problems: https://leetcode-cn.com/problems/path-with-minimum-effort/
    /// date: 20210129
    /// </summary>
    public static partial class Solution1631
    {
        public static int MinimumEffortPath(int[][] heights) {
            int m = heights.Length;
            int n = heights[0].Length;
            if(m == 1 && n == 1)
                return 0;

            int[] parent = new int[m * n];
            var connects = new List<(int Weight, int X, int Y)>();
            
            #region  初始化连接信息
            for(int i = 0; i < m - 1; i++){
                for(int j = 0; j < n - 1; j++){
                    int index = n * i + j;
                    parent[index] = index;
                    connects.Add((Math.Abs(heights[i][j] -  heights[i][j + 1]), index, index + 1));
                    connects.Add((Math.Abs(heights[i][j] -  heights[i + 1][j]), index, index + n)); 
                }
            }

            for(int i = 0; i < m - 1; i++){
                int index = n * (i + 1) - 1;
                parent[index] = index;
                connects.Add((Math.Abs(heights[i][n - 1] -  heights[i + 1][n - 1]), index, index + n)); 
            }

            for(int j = 0; j < n - 1; j++){
                int index = (m - 1) * n + j;
                parent[index] = index;
                connects.Add((Math.Abs(heights[m - 1][j] -  heights[m - 1][j + 1]), index, index + 1));
            }

            parent[m * n - 1] = m * n - 1;
            #endregion

            connects.Sort((a,b) => a.Weight - b.Weight);

            int Find(int x) => x == parent[x] ? x : parent[x] = Find(parent[x]);
            bool IsEnd() => Find(0) == Find(m * n - 1);
            
            foreach(var connect in connects){
                int rootX = Find(connect.X);
                int rootY = Find(connect.Y);
                
                if(rootX == rootY)
                    continue;
                
                parent[rootY] = parent[rootX];
                if(IsEnd())
                    return connect.Weight;
            }

            return connects[m * n - 1].Weight;
        }
    }
}