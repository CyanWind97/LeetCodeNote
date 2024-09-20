using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2374
/// title: 边积分最高的节点
/// problems: https://leetcode.cn/problems/node-with-highest-edge-score
/// date: 20240921
/// </summary>
public static class Solution2374
{
    public static int EdgeScore(int[] edges) {
        int n = edges.Length;
        var scores = new long[n];

        for (int i = 0; i < n; i++){
            scores[edges[i]] += i;
        }

        long max = 0;
        int result = 0;
        for (int i = 0; i < n; i++){
            if (scores[i] > max) {
                max = scores[i];
                result = i;
            }
        }

        return result;
    }
}
