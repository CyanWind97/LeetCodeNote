using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2673
/// title: 使二叉树所有路径值相等的最小代价
/// problems: https://leetcode.cn/problems/make-costs-of-paths-equal-in-a-binary-tree/description/?envType=daily-question&envId=2024-02-28
/// date: 20240228
/// </summary> 
public static class Solution2673
{
    public static int MinIncrements(int n, int[] cost) {
        int result = 0;
        for(int i = n - 1; i > 0; i -= 2){
            (var max, var min) = cost[i] > cost[i - 1]
                            ? (cost[i], cost[i - 1])
                            : (cost[i - 1], cost[i]);

            result += (max - min);
            cost[(i - 1) / 2] += max;
        }

        return result;
    }
}
