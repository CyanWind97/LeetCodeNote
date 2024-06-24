using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2732
/// title: 找到矩阵中的好子集
/// problems: https://leetcode.cn/problems/find-a-good-subset-of-the-matrix
/// date: 20240625
/// </summary>
public static class Solution2732
{
    // 参考解答
    public static IList<int> GoodSubsetofBinaryMatrix(int[][] grid) {
        var result = new List<int>();
        var dic = new Dictionary<int, int>();
        (int m, int n) = (grid.Length, grid[0].Length);

        for(int i = 0; i < m; i++){
            int st = 0;
            for(int j = 0; j < n; j++){
                st  |= (grid[i][j] << j);
            }

            dic[st] = i;
        }

        if (dic.ContainsKey(0)){
            result.Add(dic[0]);

            return result;
        }

        foreach(var (x, i) in dic){
            foreach(var (y, j) in dic){
                if ((x & y) == 0)
                    return [Math.Min(i, j), Math.Max(i, j)];
            }
        }

        return result;
    }
}
