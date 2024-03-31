using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 575
    /// title: 分糖果
    /// problems: https://leetcode-cn.com/problems/distribute-candies/
    /// date: 20211101
    /// </summary>
    public static class Solution575
    {
        public static int DistributeCandies(int[] candyType) {

            return Math.Min(candyType.Length / 2 , candyType.Distinct().Count());
        }
    }
}