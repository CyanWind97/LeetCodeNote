using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 633
    /// title: 扰乱字符串
    /// problems: https://leetcode-cn.com/problems/sum-of-square-numbers/
    /// date: 20210428
    /// </summary>
    public static partial class Solution633
    {
        public static bool JudgeSquareSum(int c) {

            for(long a = 0; a * a <= c; a++){
                double b = Math.Sqrt(c - a * a);
                if(b == (int)b)
                    return true;
            }

            return false;
        }
    }
}