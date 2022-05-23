using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 675
    /// title: 为高尔夫比赛砍树
    /// problems: https://leetcode.cn/problems/cut-off-trees-for-golf-event/
    /// date: 20220523
    /// </summary>
    public static class Solution675
    {
        // 参考解答 BFS
        public static int CutOffTree(IList<IList<int>> forest) {
            int[][] dirs = {new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1}};

            int row = forest.Count;
            int col = forest[0].Count;

            int BFS(int sx, int sy, int tx, int ty){
                if(sx == tx && sy == ty)
                    return 0;
                
                int step = 0;
                var queue = new Queue<(int X, int Y)>();
                var visited = new bool[row, col];
                queue.Enqueue((sx, sy));
                visited[sx, sy] = true;

                while(queue.Count > 0){
                    step++;
                    int count = queue.Count;
                    for(int i = 0; i < count; i++){
                        (var cx, var cy) = queue.Dequeue();
                        foreach(var dir in dirs){
                            int nx = cx + dir[0];
                            int ny = cy + dir[1];
                            if(nx >= 0 && nx < row && ny >= 0 && ny < col){
                                if(!visited[nx, ny] && forest[nx][ny] > 0){
                                    if(nx == tx && ny == ty)
                                        return step;
                                    
                                    queue.Enqueue((nx, ny));
                                    visited[nx, ny] = true;
                                }
                            }
                        }                  
                    }
                }

                return -1;
            }

            var trees = new List<(int X, int Y)>();
            for(int i = 0; i < row; i++){
                for(int j = 0; j < col; j++){
                    if(forest[i][j] > 1)
                        trees.Add((i, j));
                }
            }

            trees.Sort((a,b) => forest[a.X][a.Y] -  forest[b.X][b.Y]);

            (int cx, int cy) = (0, 0);
            int result = 0;
            for(int i = 0; i < trees.Count; i++){
                int steps = BFS(cx, cy, trees[i].X, trees[i].Y);
                if(steps == -1)
                    return -1;
                
                result += steps;
                (cx, cy) = trees[i];
            }

            return result;
        }
    }
}