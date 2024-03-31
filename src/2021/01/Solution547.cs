using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 547
    /// title: 省份数量
    /// problems: https://leetcode-cn.com/problems/number-of-provinces/
    /// date: 20210107
    /// </summary>
    public static class Solution547
    {
        public static int FindCircleNum(int[][] isConnected) {
            int n = isConnected.Length;
            int[] parent = new int[n];
            int count = 0;
            for(int i = 0; i < n; i++){
                parent[i] = i;
            }

            for(int i = 0; i < n; i++){
                for(int j = i + 1; j < n; j++){
                    if(isConnected[i][j] == 0)
                        continue;
                    
                    if(parent[j] == j)
                        parent[j] = i;
                    else if(parent[i] == i)
                        parent[i] = j;
                    else{
                        int rootI = parent[i];
                        int rootJ = parent[j];
                        while(parent[rootI] != rootI){
                            rootI = parent[rootI];
                        }
                        while(parent[rootJ] != rootJ){
                            rootJ = parent[rootJ];
                        }
                        
                        parent[rootI] = rootJ;
                    }
                }
            }

            for(int i = 0; i < n; i++){
                if(parent[i] == i)
                    count++;
            }
            
            return count;
        }

        // 参考解答 DFS
        public static int FindCircleNum_1(int[][] isConnected) {
            int n = isConnected.Length;
            bool[] visited = new bool[n];
            int count = 0;
            void dfs(int i){
                for(int j = 0; j < n; j++){
                    if(!visited[j] && isConnected[i][j] == 1){
                        visited[j] = true;
                        dfs(j);
                    }
                }
            }

            for(int i = 0; i < n; i++){
                if(visited[i])
                    continue;

                dfs(i);
                count++;
            }

            
            return count;
        }

        // 参考解答 BFS
        public static int FindCircleNum_2(int[][] isConnected) {
            int n = isConnected.Length;
            bool[] visited = new bool[n];
            int count = 0;
            for(int i = 0; i < n; i++){
                if(visited[i])
                    continue;

                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                while(queue.Count > 0){
                    int row = queue.Dequeue();
                    visited[row] = true;
                    for(int j = 0; j < n; j++){
                        if(visited[j] || isConnected[row][j] == 0)
                            continue;
                           
                        queue.Enqueue(j);
                    }
                }

                count++;
            }
            
            return count;
        }
    }
}