using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 934
    /// title: 最短的桥
    /// problems: https://leetcode.cn/problems/shortest-bridge/
    /// date: 20221025
    /// </summary>
    public static class Solution934
    {
        public static int ShortestBridge(int[][] grid) {
            int n = grid.Length;
            var dirs = new (int X, int Y)[]{(-1, 0), (1, 0), (0, 1), (0, -1)};
            var isLand = new List<(int X, int Y)>();
            var queue = new Queue<(int X, int Y)>();

            bool IsValidIndex(int x, int y)
                => 0 <= x && x < n && 0 <= y && y < n;

            (int X, int Y) AddPos((int X, int Y) a, (int X, int Y) b)
                => (a.X + b.X, a.Y + b.Y);

            IEnumerable<(int X, int Y)> GetNextPos((int X, int Y) pos){
                foreach(var dir in dirs){
                    var nPos = AddPos(pos, dir);
                    if(!IsValidIndex(nPos.X, nPos.Y))
                        continue;
                    
                    yield return nPos;
                }
            }

            
            bool find = false;
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    if(grid[i][j] == 0)
                        continue;
                    
                    queue.Enqueue((i, j));
                    grid[i][j] = -1;
                    find = true;
                    break;
                }

                if(find)
                    break;
            }

            
            while(queue.Count > 0){
                var pos = queue.Dequeue();
                isLand.Add(pos);
                
                foreach(var nPos in GetNextPos(pos)){
                    if(grid[nPos.X][nPos.Y] != 1)
                        continue;

                    queue.Enqueue(nPos);
                    grid[nPos.X][nPos.Y] = -1;
                }
            }

            queue = new Queue<(int X, int Y)>(isLand);
            int step = 0;
            while(queue.Count > 0){
                int size = queue.Count;

                for(int k = 0; k < size; k++){
                    var pos = queue.Dequeue();
                    foreach(var nPos in GetNextPos(pos)){
                        if(grid[nPos.X][nPos.Y] == 0){
                            queue.Enqueue(nPos);
                            grid[nPos.X][nPos.Y] = -1;
                        }else if(grid[nPos.X][nPos.Y] == 1){
                            return step;
                        }
                    }
                }

                step++;
            }

            return 0;
        }

        
    }
}