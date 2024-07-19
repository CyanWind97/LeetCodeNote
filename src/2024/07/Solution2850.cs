using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2850
/// title: 将石头分散到网格图的最少移动次数
/// problems: https://leetcode.cn/problems/minimum-moves-to-spread-stones-over-grid
/// date: 20240720
/// </summary>
public static class Solution2850
{
    // 参考解答
    public static int MinimumMoves(int[][] grid) {
        var more = new List<(int X, int Y)>();
        var less = new List<(int X, int Y)>();

        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                if (grid[i][j] > 1)
                    more.AddRange(Enumerable.Range(0, grid[i][j] - 1)
                                    .Select(_ => (i, j)));
                else if (grid[i][j] == 0)
                    less.Add((i, j));
            }
        }

        var result = int.MaxValue;

        bool IsLess((int X, int Y) p1, (int X, int Y) p2) 
            => p1.X < p2.X || p1.X == p2.X && p1.Y < p2.Y;

        bool NextPremutation(){
            int p = Enumerable.Range(0, more.Count - 1)
                        .LastOrDefault(i => IsLess(more[i], more[i + 1]), -1);
            
            if (p == -1)
                return false;
            
            int q = Enumerable.Range(p + 1, more.Count - p - 1)
                        .LastOrDefault(i => IsLess(more[p], more[i]), -1);

            (more[p], more[q]) = (more[q], more[p]);
            int i = p + 1;
            int j = more.Count - 1;

            while (i < j)
            {
                (more[i], more[j]) = (more[j], more[i]);
                i++;
                j--;
            }

            return true;
        }

        do{
            int steps = 0;
            for(int i = 0; i < more.Count; i++){
                steps += Math.Abs(more[i].X - less[i].X) + Math.Abs(more[i].Y - less[i].Y);
            }

            result = Math.Min(result, steps);
        }while(NextPremutation());

        return result;
    }
}
