using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 699
    /// title: 掉落的方块
    /// problems: https://leetcode.cn/problems/falling-squares/
    /// date: 20220526
    /// </summary>
    public static partial class Solution699
    {
        // 参考解答
        public static IList<int> FallingSquares(int[][] positions) {
            int n = positions.Length;
            IList<int> heights = new List<int>();
            for (int i = 0; i < n; i++) {
                int left1 = positions[i][0], right1 = positions[i][0] + positions[i][1] - 1;
                heights.Add(positions[i][1]);
                for (int j = 0; j < i; j++) {
                    int left2 = positions[j][0], right2 = positions[j][0] + positions[j][1] - 1;
                    if (right1 >= left2 && right2 >= left1) {
                        heights[i] = Math.Max(heights[i], heights[j] + positions[i][1]);
                    }
                }
            }

            for (int i = 1; i < n; i++) {
                heights[i] = Math.Max(heights[i], heights[i - 1]);
            }
            
            return heights;
        }
    }
}