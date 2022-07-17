using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 749
    /// title: 隔离病毒
    /// problems: https://leetcode.cn/problems/contain-virus/
    /// date: 20220718
    /// </summary>
    public static class Solution749
    {
        // 参考解答 BFS
        public static int ContainVirus(int[][] isInfected) {
            int GetHash(int x, int y)
                => (x << 16) ^ y;
            
            var dirs = new (int X, int Y)[]{(-1, 0), (1, 0), (0, -1), (0, 1)};
            int m = isInfected.Length, n = isInfected[0].Length;
            bool IsValid(int x, int y)
                => x >= 0 && x < m &&  y >= 0 && y < n;

            int result = 0;
            while(true){
                var neighbors = new List<ISet<int>>();
                var firewalls = new List<int>();
                for(int i = 0; i < m; i++){
                    for(int j = 0; j < n; j++){
                        if(isInfected[i][j] != 1)
                            continue;
                        
                        var queue = new Queue<(int X, int Y)>();
                        queue.Enqueue((i, j));
                        var neighbor = new HashSet<int>();
                        int firewall = 0, idx = neighbors.Count + 1;
                        isInfected[i][j] = -idx;
                        while(queue.Count > 0){
                            (int x, int y) = queue.Dequeue();
                            foreach(var dir in dirs){
                                int nx = x + dir.X;
                                int ny = y + dir.Y;
                                if(!IsValid(nx, ny))
                                    continue;
                                
                                if(isInfected[nx][ny] == 1){
                                    queue.Enqueue((nx, ny));
                                    isInfected[nx][ny] = -idx;
                                }else if(isInfected[nx][ny] == 0){
                                    ++firewall;
                                    neighbor.Add(GetHash(nx, ny));
                                }
                            }
                        }
                        
                        neighbors.Add(neighbor);
                        firewalls.Add(firewall);
                    }
                }

                if(neighbors.Count == 0)
                    break;
                
                int maxIdx = 0;
                for(int i = 1; i < neighbors.Count; i++){
                    if(neighbors[i].Count > neighbors[maxIdx].Count)
                        maxIdx = i;
                }

                result += firewalls[maxIdx];
                for(int i = 0; i < m; i++){
                    for(int j = 0; j < n; j++){
                        if(isInfected[i][j] < 0){
                            if(isInfected[i][j] != -maxIdx - 1)
                                isInfected[i][j] = 1;
                            else
                                isInfected[i][j] = 2;                            
                        }
                    }
                }

                for(int i = 0; i < neighbors.Count; i++){
                    if(i == maxIdx)
                        continue;
                    
                    foreach(int val in neighbors[i]){
                        int x = val >> 16, y = val & ((1 << 16) - 1);
                        isInfected[x][y] = 1;
                    }
                }

                if(neighbors.Count == 1)
                    break;
            }

            return result;
        }
    }
}