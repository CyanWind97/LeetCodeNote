using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 646
    /// title: 最长数对链
    /// problems: https://leetcode.cn/problems/maximum-length-of-pair-chain/
    /// date: 20220903
    /// </summary>
    public static class Solution646
    {
        public static int FindLongestChain(int[][] pairs) {
            int cur = int.MinValue;
            int result = 0;
            Array.Sort(pairs, (a, b) => a[1] - b[1]);
            foreach (int[] p in pairs) {
                if (cur < p[0]) {
                    cur = p[1];
                    result++;
                }
            }
            
            return result;
        }
    }
}