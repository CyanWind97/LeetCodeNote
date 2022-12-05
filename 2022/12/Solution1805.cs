using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1805
    /// title:  字符串中不同整数的数目
    /// problems: https://leetcode.cn/problems/number-of-different-integers-in-a-string/
    /// date: 20221206
    /// </summary>
    public static class Solution1805
    {
        public static int NumDifferentIntegers(string word) {
            return Regex.Split(word, @"[a-z]+")
                        .Where(s => !string.IsNullOrEmpty(s))
                        .Select(s => s.TrimStart('0'))
                        .Distinct()
                        .Count();
        }   
    }
}