using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1725
    /// title: 以形成最大正方形的矩形数目
    /// problems: https://leetcode-cn.com/problems/number-of-rectangles-that-can-form-the-largest-square/
    /// date: 20220204
    /// </summary>
    public static class Solution1725
    {
        public static int CountGoodRectangles(int[][] rectangles) {
            int count = 0;
            int maxLen = 0;
            foreach(var rectangle in rectangles){
                var len = Math.Min(rectangle[0], rectangle[1]);
                if(len > maxLen){
                    maxLen = len;
                    count = 1;
                }else if (len == maxLen){
                    count++;
                }
            }

            return count;
        }
    }
}