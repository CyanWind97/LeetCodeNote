using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1423
    /// title: 可获得的最大点数
    /// problems: https://leetcode-cn.com/problems/maximum-points-you-can-obtain-from-cards/
    /// date: 20210206
    /// </summary>

    public static partial class Solution1423
    {
        public static int MaxScore(int[] cardPoints, int k) {
            int length = cardPoints.Length;
            int curScore = cardPoints.Skip(length - k).Take(k).Sum();
            if(length == k)
                return curScore;
            
            int maxScore = curScore;
            int index = length - k;
            while(index < length){
                curScore +=  cardPoints[(index + k) % length] - cardPoints[index++];
                maxScore = Math.Max(maxScore, curScore);
            }

            return maxScore;
        }
    }
}