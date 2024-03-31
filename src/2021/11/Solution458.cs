using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 458
    /// title: 可怜的小猪
    /// problems: https://leetcode-cn.com/problems/poor-pigs/
    /// date: 20211125
    /// </summary>
    public static class Solution458
    {
        public static int PoorPigs(int buckets, int minutesToDie, int minutesToTest) {
            if (buckets == 0)
                return 0;

            var n = minutesToTest / minutesToDie + 1;
            int count = 0;
            int pow = 1;
            while(pow < buckets) {
                pow *= n;
                count++;
            }

            return count;
        }

        // 参考写法
        public static int PoorPigs_1(int buckets, int minutesToDie, int minutesToTest) {
            int states = minutesToTest / minutesToDie + 1;
            int pigs = (int) Math.Ceiling(Math.Log(buckets) / Math.Log(states));
            return pigs;
        }
    }
}