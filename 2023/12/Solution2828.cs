using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2828
    /// title: 判别首字母缩略词
    /// problems: https://leetcode.cn/problems/check-if-a-string-is-an-acronym-of-words/description/?envType=daily-question&envId=2023-12-20
    /// date: 20231220
    /// </summary>
    public static class Solution2828
    {
        public static bool IsAcronym(IList<string> words, string s) {

            return words.Count == s.Length 
                && words.Zip(s, (w, c) => w[0] == c).All(b => b);
        }
    }
}