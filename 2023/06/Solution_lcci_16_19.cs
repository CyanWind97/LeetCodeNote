using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 16.19
    /// title: 水域大小
    /// problems: https://leetcode.cn/problems/pond-sizes-lcci/
    /// date: 20230622
    /// type: 面试题 lcci
    /// </summary>
    public static class Solution_lcci_16_19
    {
        public static int[] PondSizes(int[][] land) {
            var m = land.Length;
            var n = land[0].Length;
            var dirs = new (int X, int Y)[]
            {
                (1, 0), (0, 1), (-1, 0), (0, -1),
                (1, 1), (1, -1), (-1, 1), (-1, -1)
            };

            var result = new List<int>();
            var visited = new bool[m, n];

            IEnumerable<(int X, int Y)> GetAdjacentWaters(int x, int y){
                foreach(var dir in dirs){
                    int nextX = x + dir.X;
                    int nextY = y + dir.Y;
                    if(nextX >= 0 && nextX < m 
                        && 0 <= nextY && nextY < n 
                        && land[nextX][nextY] == 0
                        && !visited[nextX, nextY]){
                        yield return (nextX, nextY);
                    }
                }
            }

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    if (land[i][j] != 0 || visited[i, j])
                        continue;
                    
                    var queue = new Queue<(int X, int Y)>();
                    queue.Enqueue((i, j));
                    visited[i, j] = true;
                    int count = 0;
                    while(queue.Count > 0){
                        var (x, y) = queue.Dequeue();
                        count++;
                        foreach(var next in GetAdjacentWaters(x, y)){
                            queue.Enqueue(next);
                            visited[next.X, next.Y] = true;
                        }
                    }

                    result.Add(count);
                }
            }

            result.Sort();

            return result.ToArray();
        }
    }
}