using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 598
    /// title: 范围求和 II
    /// problems: https://leetcode-cn.com/problems/range-addition-ii/
    /// date: 20211107
    /// </summary>
    public static class Solution598
    {
        public static int MaxCount(int m, int n, int[][] ops) {
            int minM = m;
            int minN = n;
            
            foreach(var pair in ops){
                minM = Math.Min(minM, pair[0]);
                minN = Math.Min(minN, pair[1]);
            }

            return minM * minN;
        }
    }
}