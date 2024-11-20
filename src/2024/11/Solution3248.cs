using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3248
/// title: 矩阵中的蛇
/// problems: https://leetcode.cn/problems/snake-in-matrix
/// date: 20241121
/// </summary>
public static class Solution3248
{
    public static int FinalPositionOfSnake(int n, IList<string> commands) {
        int result = 0;
        foreach(var command in commands){
            var delta = command[0] switch
            {
                'U' => -n,
                'D' => n,
                'L' => -1,
                _ => 1
            };

            result += delta;
        }

        return result;
    }
}
