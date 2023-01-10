using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2283
    /// title: 判断一个数的数字计数是否等于数位的值
    /// problems: https://leetcode.cn/problems/check-if-number-has-equal-digit-count-and-digit-value/
    /// date: 20230111
    /// </summary>
    public static class Solution2283
    {
        public static bool DigitCount(string num) {
            int n = num.Length;
            int[] count = new int[n];
            foreach(var c in num){
                int index = c - '0';
                if(index >= n)
                    return false;

                count[c - '0']++;
            }

            return string.Join("", count) == num;
        }
    }
}