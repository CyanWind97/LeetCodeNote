using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 492
    /// title: 构造矩形
    /// problems: https://leetcode-cn.com/problems/construct-the-rectangle/
    /// date: 20211023
    /// </summary>
    public static class Solution492
    {
        public static int[] ConstructRectangle(int area) {
            var x = (int)Math.Floor(Math.Sqrt(area));
            for(int i = x; i >= 1; i--){
                if (area % i == 0)
                    return new int[]{area / i, i};
            }

            return null;
        }
    }
}