using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2373
    /// title: 矩阵中的局部最大值
    /// problems: https://leetcode.cn/problems/largest-local-values-in-a-matrix/
    /// date: 20230301
    /// </summary>
    public static class Solution2373
    {
        public static int[][] LargestLocal(int[][] grid) {
            int n = grid.Length;
            var result = Enumerable.Range(0, n - 2)
                                .Select(i => new int[n - 2])
                                .ToArray();

            IEnumerable<(int X, int Y)> GetRange(int x, int y){
                (int minX, int maxX) = (Math.Max(0, x - 2), Math.Min(x, n - 3));
                (int minY, int maxY) = (Math.Max(0, y - 2), Math.Min(y, n - 3));

                for(int i = minX; i <= maxX; i++){
                    for(int j = minY; j <= maxY; j++){
                        yield return (i, j);
                    }
                }
            }

            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    int num = grid[i][j];
                    foreach(var point in GetRange(i, j)){
                        result[point.X][point.Y] = Math.Max(result[point.X][point.Y], num);
                    }
                }
            }

            return result;
        }
    }
}