using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1465
    /// title: 切割后面积最大的蛋糕
    /// problems: https://leetcode.cn/problems/maximum-area-of-a-piece-of-cake-after-horizontal-and-vertical-cuts/?envType=daily-question&envId=2023-10-27
    /// date: 20231027
    /// </summary>
    public static class Solution1465
    {
        public static int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) {
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);
            int maxH = Math.Max(horizontalCuts[0], h - horizontalCuts[^1]);
            int maxW = Math.Max(verticalCuts[0], w - verticalCuts[^1]);
            for (int i = 1; i < horizontalCuts.Length; i++) {
                maxH = Math.Max(maxH, horizontalCuts[i] - horizontalCuts[i - 1]);
            }
            for (int i = 1; i < verticalCuts.Length; i++) {
                maxW = Math.Max(maxW, verticalCuts[i] - verticalCuts[i - 1]);
            }
            
            return (int)((long)maxH * maxW % 1000000007);
        }
    }
}