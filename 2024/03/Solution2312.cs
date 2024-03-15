using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2312
/// title:  卖木头块
/// problems: https://leetcode.cn/problems/selling-pieces-of-wood
/// date: 20240315
/// </summary>
public static class Solution2312
{   
    // 参考解答
    // 记忆搜索
    public static long SellingWood(int m, int n, int[][] prices) {
        var value = new Dictionary<(int H, int W), int>();
        foreach (int[] price in prices) {
            value[(price[0], price[1])] = price[2];
        }

        var memo = new long[m + 1, n + 1];
        for (int i = 0; i <= m; i++) {
            for (int j = 0; j <= n; j++) {
                memo[i, j] = -1;
            }
        }

        long DFS(int x, int y) {
            if (memo[x, y] != -1) 
                return memo[x, y];
            

            var key = (x, y);
            long result = value.ContainsKey(key) ? value[key] : 0;
            if (x > 1) {
                for (int i = 1; i < x; i++) {
                    result = Math.Max(result, DFS(i, y) + DFS(x - i, y));
                }
            }
            if (y > 1) {
                for (int j = 1; j < y; j++) {
                    result = Math.Max(result, DFS(x, j) + DFS(x, y - j));
                }
            }
            memo[x, y] = result;
            return result;
        }

        return DFS(m, n);
    }
}
