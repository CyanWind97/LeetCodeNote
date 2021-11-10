using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 495
    /// title: 提莫攻击
    /// problems: https://leetcode-cn.com/problems/teemo-attacking/
    /// date: 20211110
    /// </summary>
    public class Solution495
    {
        public static int FindPoisonedDuration(int[] timeSeries, int duration) {
            int length = timeSeries.Length;
            int result = duration;
            for(int i = 1; i < length; i++){
                result += Math.Min(timeSeries[i] - timeSeries[i - 1], duration);
            }

            return result;
        }
    }
}