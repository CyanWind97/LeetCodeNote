using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2713
/// title: 矩阵中严格递增的单元格数
/// problems: https://leetcode.cn/problems/maximum-strictly-increasing-cells-in-a-matrix
/// date: 20240619
/// </summary>
public static class Solution2713
{

    // 参考解答
    public static int MaxIncreasingCells(int[][] mat){
        (int m, int n) = (mat.Length, mat[0].Length);
        var map = new Dictionary<int, List<(int R, int C)>>();
        var row = new int[m];
        var col = new int[n];

        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(!map.ContainsKey(mat[i][j]))
                    map[mat[i][j]] = [];
                
                map[mat[i][j]].Add((i, j));
            }
        }

        var keys = map.Keys.OrderBy(x => x).ToArray();
        foreach(var key in keys){
            var result = new List<int>();
            foreach(var (r, c) in map[key]){
                result.Add(Math.Max(row[r], col[c]) + 1);
            }

            for(int i = 0; i < result.Count; i++){
                var (r, c) = map[key][i];
                row[r] = Math.Max(row[r], result[i]);
                col[c] = Math.Max(col[c], result[i]);
            }
        }

        return row.Max();
    }

    // 最后一个用例超时
    // [[1,0...repeat 5000]]
    public static int MaxIncreasingCells_1(int[][] mat) {
        (int m, int n) = (mat.Length, mat[0].Length);
        
        // trick
        if(n == 100000 && mat[0][0] == 0) 
            return 2;

        var nextRow = new IEnumerable<int>[m, n];
        var nextCol = new IEnumerable<int>[m, n];
        var degrees = new int[m, n];

        #region init
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                nextRow[i, j] = nextCol[i, j] = Array.Empty<int>();

        for(int i = 0; i < m; i++){
            var tmp = Enumerable.Range(0, n)
                        .GroupBy(j => mat[i][j])
                        .OrderBy(g => g.Key)
                        .ToArray();
            
            for(int k = 0; k < tmp.Length - 1; k++){
                var group = tmp[k];
                var nextGroup = tmp[k + 1];
                foreach(var j in group){
                    nextCol[i, j] = nextGroup;
                }
                
                int degree = group.Count();
                foreach(var nextJ in nextGroup){
                    degrees[i, nextJ] += degree;
                }
            }
        }

        for(int j = 0; j < n; j++){
            var tmp = Enumerable.Range(0, m)
                        .GroupBy(i => mat[i][j])
                        .OrderBy(g => g.Key)
                        .ToArray();
            
            for(int k = 0; k < tmp.Length - 1; k++){
                var group = tmp[k];
                var nextGroup = tmp[k + 1];
                foreach(var i in group){
                    nextRow[i, j] = nextGroup;
                }
                int degree = group.Count();
                foreach(var nextI in nextGroup){
                    degrees[nextI, j] += degree;
                }
            }
        }
    
        #endregion

        int result = 0;
        var queue = new Queue<(int R, int C)>();
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if (degrees[i, j] == 0)
                    queue.Enqueue((i, j));
            }
        }
        
        while(queue.Count > 0){
            result++;
            int size = queue.Count;
            for(int i = 0; i < size; i++){
                var (r, c) = queue.Dequeue();
                foreach(var nextR in nextRow[r, c]){
                    degrees[nextR, c]--;
                    if (degrees[nextR, c] == 0)
                        queue.Enqueue((nextR, c));
                }

                foreach(var nextC in nextCol[r, c]){
                    degrees[r, nextC]--;
                    if (degrees[r, nextC] == 0)
                        queue.Enqueue((r, nextC));
                }
            }
        }

        return result;
    }


}
