using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 778
    /// title: 水位上升的泳池中游泳
    /// problems: https://leetcode-cn.com/problems/swim-in-rising-water/
    /// date: 20210130
    /// </summary>
    public static class Solution778
    {
        public static int SwimInWater(int[][] grid) {
            int n = grid.Length;
            int[] parent = new int[n * n];
            var points = new (int H, int X, int Y)[n * n];
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    int index = i * n + j;
                    parent[index] = index;
                    points[index] = (grid[i][j], i, j);
                }
            }

            Array.Sort(points, (a,b) => a.H - b.H);

            int Find(int x) => x == parent[x] ? x : parent[x] = Find(parent[x]);
            void Union(int x, int y){
                int rootX = Find(x);
                int rootY = Find(y);
                
                if(rootX == rootY)
                    return;
                
                parent[rootY] = rootX;
            }
            bool IsEnd() => Find(0) == Find(n * n - 1);

            foreach(var point in points){
                int i = point.X;
                int j = point.Y;
                int index = i* n + j;
                if(i != 0 && point.H >= grid[i - 1][j])
                    Union(index, index - n);
                
                if(i!= n - 1 && point.H >= grid[i + 1][j])
                    Union(index, index + n);
                
                if(j != 0 && point.H >= grid[i][j - 1])
                    Union(index, index - 1);
                
                if(j != n - 1 && point.H >= grid[i][j + 1])
                    Union(index, index + 1);
                
                if(IsEnd())
                    return point.H;
            }

            return points[n * n - 1].H;
        }
    }
}