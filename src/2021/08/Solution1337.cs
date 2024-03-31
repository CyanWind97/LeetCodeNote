using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1337
    /// title:  矩阵中战斗力最弱的 K 行
    /// problems: https://leetcode-cn.com/problems/the-k-weakest-rows-in-a-matrix/
    /// date: 20210801
    /// </summary>
    public static class Solution1337
    {
        public static int[] KWeakestRows(int[][] mat, int k) {
            int m = mat.Length;
            int n = mat[0].Length;
            int[] result = new int[k];
            bool[] visited = new bool[m];
            int index = 0;

            for(int j = 0; j < n && index < k; j++){
                for(int i = 0; i < m && index < k; i++){
                    if(visited[i])
                        continue;

                    if(mat[i][j] == 0){
                        result[index++] = i;
                        visited[i] = true;
                    }
                }
            }
            
            for(int i = 0; i < m && index < k; i++){
                if(!visited[i])
                    result[index++] = i;
            }

            return result;
        }
    }
}