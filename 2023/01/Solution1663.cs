using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1633
    /// title: 具有给定数值的最小字符串
    /// problems: https://leetcode.cn/problems/smallest-string-with-a-given-numeric-value/
    /// date: 20230126
    /// </summary>
    public static class Solution1663
    {
        public static string GetSmallestString(int n, int k) {
            var chars = new char[n];
            Array.Fill(chars, 'a');

            int index = n - 1;
            k -= n;

            while(k > 0){
                var add = Math.Min(k, 25);
                chars[index] = (char)('a' + add);
                index--;
                k -= add;
            }

            return new string(chars);
        }
    }
}