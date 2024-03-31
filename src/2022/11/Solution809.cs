using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 809
    /// title: 情感丰富的文字
    /// problems: https://leetcode.cn/problems/expressive-words/
    /// date: 20221125
    /// </summary>
    public static class Solution809
    {
        
        public static int ExpressiveWords(string s, string[] words) {
            bool Expand(string t) {
                int i = 0, j = 0;
                while (i < s.Length && j < t.Length) {
                    if (s[i] != t[j]) {
                        return false;
                    }
                    char ch = s[i];
                    int cnti = 0;
                    while (i < s.Length && s[i] == ch) {
                        ++cnti;
                        ++i;
                    }
                    int cntj = 0;
                    while (j < t.Length && t[j] == ch) {
                        ++cntj;
                        ++j;
                    }
                    if (cnti < cntj) {
                        return false;
                    }
                    if (cnti != cntj && cnti < 3) {
                        return false;
                    }
                }
                return i == s.Length && j == t.Length;
            }
            

            return words.Count(word => Expand(word));
        }
    }
}