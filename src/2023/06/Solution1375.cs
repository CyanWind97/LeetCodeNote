using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1375
    /// title: 二进制字符串前缀一致的次数
    /// problems: https://leetcode.cn/problems/number-of-times-binary-string-is-prefix-aligned/
    /// date: 20230614
    /// </summary>
    public static class Solution1375
    {
        public static int NumTimesAllBlue(int[] flips) {
            int length = flips.Length;
            int result = 0;
            int max = 0;
            for(int i = 0; i < length; i++){
                max = Math.Max(max, flips[i]);
                if(max == i + 1)
                    result++;
            }

            return result;
        }
    }
}