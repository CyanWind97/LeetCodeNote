using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 200
    /// title:   岛屿数量
    /// problems: https://leetcode-cn.com/problems/number-of-islands/
    /// date: 20220508
    /// priority: 0020
    /// time: 00:13:09.10
    /// </summary>
    public static class CodeTop200
    {
        public static int NumIslands(char[][] grid) 
        {
            int m = grid.Length;
            int n = grid[0].Length;
            var visited = new bool[m, n];
            int count = 0;

            IEnumerable<(int R, int C)> GetAdjacentPoint((int R, int C) point)
            {
                bool IsValid(int x, int y)
                    => !visited[x, y] && grid[x][y] == '1';

                if (point.R > 0 && IsValid(point.R - 1, point.C))
                    yield return (point.R - 1, point.C);
                
                if(point.R < m - 1 && IsValid(point.R + 1, point.C))
                    yield return (point.R + 1, point.C);
                
                if(point.C > 0 && IsValid(point.R, point.C - 1))
                    yield return (point.R, point.C - 1);
                
                if(point.C < n - 1 && IsValid(point.R, point.C + 1))
                    yield return (point.R, point.C + 1);
            }

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++){
                    if(visited[i, j])
                        continue;
                    
                    visited[i, j] = true;
                    if(grid[i][j] == '0')
                        continue;
                    
                    var queue = new Queue<(int R, int C)>();
                    queue.Enqueue((i, j));

                    while(queue.Count > 0){
                        var point = queue.Dequeue();

                        foreach(var adPoint in GetAdjacentPoint(point)){
                            visited[adPoint.R, adPoint.C] = true;
                            queue.Enqueue(adPoint);
                        }
                    }

                    count++;
                }

            }


            return count;
        }
    }
}