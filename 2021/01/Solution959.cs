using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 959
    /// title: 由斜杠划分区域
    /// problems: https://leetcode-cn.com/problems/regions-cut-by-slashes/
    /// date: 20210125
    /// </summary>
    public static class Solution959
    {
        public static int RegionsBySlashes(string[] grid) {
            int n = grid.Length + 1;
            int[] parent = new int[n * n];    
            
            for(int i = 1; i < n - 1; i++){
                for(int j = 1; j < n - 1; j++){
                    parent[i * n + j] = i * n + j;
                }
            }

            int Find(int x) => x == parent[x] ? x : parent[x] = Find(parent[x]);

            int result = 1;
            
            for(int i = 0; i < n - 1; i++){
                char[] chars = grid[i].ToCharArray();
                for(int j = 0; j < n - 1; j++){
                    if(chars[j] == ' ')
                        continue;

                    int rootX = 0;
                    int rootY = 0;

                    if(chars[j] == '/'){
                        rootX = Find((i + 1) * n + j);
                        rootY = Find(i * n + j + 1);
                    }else{
                        rootX = Find(i * n + j);
                        rootY = Find((i + 1) * n + j + 1);
                    }

                    if(rootX == rootY)
                        result++;
                    else
                        parent[rootY] = rootX;
                }
            }

            return result;
        }
    }
}