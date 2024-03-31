using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 803
    /// title: 打砖块
    /// problems: https://leetcode-cn.com/problems/bricks-falling-when-hit/
    /// date: 20210116
    /// </summary>
    public static class Solution803
    {
        // 参考解答  并查集合  逆序 虚拟屋顶
        public static int[] HitBricks(int[][] grid, int[][] hits) {
            int m = grid.Length;
            int n = grid[0].Length;
            int length = hits.Length;

            int[] origin = new int[length];

            for(int i = 0; i < length; i++){
                int x = hits[i][0];
                int y = hits[i][1];

                origin[i] = grid[x][y];
                grid[x][y] = 0;
            }

            #region UnionFind
            int size = m * n;
            int[] parent = new int[size + 1];
            int[] count = new int[size + 1];

            for(int i = 0; i < size + 1; i++){
                parent[i] = i;
                count[i] = 1;
            }

            int Find(int x){
                if(x != parent[x]){
                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }

            void Union(int x, int y){
                int rootX = Find(x);
                int rootY = Find(y);

                if(rootX == rootY)
                    return;
                
                parent[rootY] = rootX;
                count[rootX] += count[rootY];
            }
            #endregion

            #region 构建并查集
            for(int j = 0; j < n; j++){
                if(grid[0][j] == 1){
                    parent[j] = size;
                    count[size]++;
                }
            }

            for(int i = 1; i < m; i++){
                int row = i * n;
                for(int j = 0; j < n; j++){
                    if(grid[i][j] == 1){
                        int index = row + j;
                        if(grid[i - 1][j] == 1)
                            Union(index - n, index);
                        
                        if(j > 0 && grid[i][j - 1] == 1)
                            Union(index - 1, index);
                    }
                }
            }
            #endregion

            int[] result = new int[length];
            for(int i = length - 1; i >= 0; i--){
                if(origin[i] == 0)
                    continue;
                
                int x = hits[i][0];
                int y = hits[i][1];

                int pre = count[Find(size)];

                if(x == 0){
                    Union(size, y);
                }

                int index = x * n + y;
                if(x > 0 && grid[x - 1][y] == 1)
                    Union(index - n, index);
                
                if(x < m - 1 && grid[x + 1][y] == 1)
                    Union(index + n, index);
                
                if(y > 0 && grid[x][y - 1] == 1)
                    Union(index - 1, index);
                
                if(y < n - 1 && grid[x][y + 1] == 1)
                    Union(index + 1, index);
                
                int cur = count[Find(size)];
                if(cur > pre)
                    result[i] = cur - pre - 1;
                grid[x][y] = 1;
            }

            return result;
        }
    }
}