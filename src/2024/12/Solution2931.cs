using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2931
/// title: 购买物品的最大开销
/// problems: https://leetcode.cn/problems/maximum-spending-after-buying-items
/// date: 20241212
/// </summary>
public static class Solution2931
{
    public static long MaxSpending(int[][] values) {
        var (m, n) = (values.Length, values[0].Length);
        long result = 0;
        var pq = new PriorityQueue<(int Store, int Index), int>();
        for (int i = 0; i < m; i++){
            pq.Enqueue((i, n - 1), values[i][n - 1]);
        }

        for (int i = 0; i < m * n; i++){
            var (store, index) = pq.Dequeue();
            result += (long)(i + 1) * values[store][index];
            if (index > 0){
                pq.Enqueue((store, index - 1), values[store][index - 1]);
            }
        }

        return result;
    }
}
