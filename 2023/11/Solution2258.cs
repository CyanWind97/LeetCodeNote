using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2258
    /// title: 逃离火灾
    /// problems: https://leetcode.cn/problems/escape-the-spreading-fire/description/?envType=daily-question&envId=2023-11-09
    /// date: 20231109
    /// </summary>
    public static class Solution2258
    {
        // 参考解答
        public static int MaximumMinutes(int[][] grid) {
            var dirs = new (int X, int Y)[]{(-1, 0), (1, 0), (0, -1), (0, 1)};
            (int m, int n) = (grid.Length, grid[0].Length);

            (int Home, int HomeLeft, int HomeTop) BFS(List<(int X, int Y)> points){
                var time = new int[m, n];
                for(var i = 0; i < m; i++){
                    for(var j = 0; j < n; j++){
                        time[i, j] = -1;
                    }
                }

                foreach(var (x, y) in points){
                    time[x, y] = 0;
                }

                for(int t = 1; points.Count > 0; t++){
                    var tmp = new List<(int X, int Y)>();
                    foreach(var (px, py) in points){
                        foreach(var (dx, dy) in dirs){
                            int x = px + dx;
                            int y = py + dy;
                            if(x >= 0 && x < m && y >= 0 && y < n 
                            && grid[x][y] == 0 && time[x, y] == -1){
                                time[x, y] = t;
                                tmp.Add((x, y));
                            }
                        }
                    }

                    points = tmp;
                }

                return (time[m - 1, n - 1], time[m - 1, n - 2], time[m - 2, n - 1]);
            }
        
            
            var human = BFS(new List<(int X, int Y)>{(0, 0)});
            if (human.Home < 0)
                return -1;

            var firePos = new List<(int X, int Y)>();
            for(var i = 0; i < m; i++){
                for(var j = 0; j < n; j++){
                    if(grid[i][j] == 1){
                        firePos.Add((i, j));
                    }
                }
            }

            var fire = BFS(firePos);
            if (fire.Home < 0)
                return 1_000_000_000;

            int d = fire.Home - human.Home;
            if (d < 0)
                return -1;
            
            if (human.HomeLeft != -1 && human.HomeLeft + d < fire.HomeLeft
            || human.HomeTop != -1 && human.HomeTop + d < fire.HomeTop)
                return d;

            return d - 1;
        }
    }
}