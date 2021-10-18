using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 476
    /// title: 数字的补数
    /// problems: https://leetcode-cn.com/problems/number-complement/
    /// date: 20211018
    /// </summary>
    public static class Solution476
    {
        public static int FindComplement(int num) {
            int n = num;
            long max = 1;
            while(n > 0){
                n >>= 1;
                max <<= 1;
            }

            return (int)(max + ~num);
        }

        // 参考解答
        public static int FindComplement_1(int num) {
            int t = num;
            t |= t >> 1;
            t |= t >> 2;
            t |= t >> 4;
            t |= t >> 8;
            t |= t >> 16;
            
            return ~num & t;
        }
    }
}