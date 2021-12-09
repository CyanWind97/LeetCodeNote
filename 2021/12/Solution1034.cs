using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1034
    /// title: 边界着色
    /// problems: https://leetcode-cn.com/problems/coloring-a-border/
    /// date: 20211207
    /// </summary>
    public static class Solution1034
    {
        public static int[][] ColorBorder(int[][] grid, int row, int col, int color) {
            int m = grid.Length;
            int n = grid[0].Length;

            // 0 未访问, 1 访问过且不同色, 2访问且同色
            int[,] visited = new int[m, n];

            IEnumerable<(int X, int Y)> GetAdjacentPoints((int X, int Y) point)
            {
                if(point.X > 0 )
                    yield return (point.X - 1, point.Y);

                if(point.X < m - 1)
                    yield return(point.X + 1, point.Y);
                
                if(point.Y > 0)
                    yield return(point.X, point.Y - 1);
                
                if(point.Y < n - 1)
                    yield return(point.X, point.Y + 1);
            }
            
            bool IsVisited((int X, int Y) point)
                => visited[point.X, point.Y] != 0;

            var borderPoints = new List<(int X, int Y)>();
            
            var queue = new Queue<(int X, int Y)>();
            int target = grid[row][col];
            queue.Enqueue((row, col));
            
            while(queue.Count > 0){
                var point = queue.Dequeue();
                if (IsVisited(point))
                    continue;
                
                bool isSame = grid[point.X][point.Y] == target;
                visited[point.X, point.Y] = isSame ? 2 : 1;
                
                if (!isSame)
                    continue;
                
                foreach(var adjacentPoint in GetAdjacentPoints(point).Where(p => !IsVisited(p))){
                    queue.Enqueue(adjacentPoint);
                }
            }

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    if(visited[i, j] != 2)
                        continue;
                    
                    var points = GetAdjacentPoints((i, j)).ToList();
                    if(points.Count < 4 || points.Any(p => visited[p.X, p.Y] != 2))
                        grid[i][j] = color;
                }
            }

            return grid;
        }
    }
}