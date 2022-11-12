using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 791
    /// title: 自定义字符串排序
    /// problems: https://leetcode.cn/problems/custom-sort-string/
    /// date: 20221113
    /// </summary> 
    public static class Solution791
    {
        public static string CustomSortString(string order, string s) {
            var map = new int[26];
            for (int i = 0; i < order.Length; ++i) {
                map[order[i] - 'a'] = i + 1;
            }

            var chars = s.ToCharArray();
            Array.Sort(chars, (c0, c1) => map[c0 - 'a'] - map[c1 - 'a']);
            
            return new string(chars);
        }
    }
}