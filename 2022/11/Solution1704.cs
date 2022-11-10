using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1704
    /// title: 判断字符串的两半是否相似
    /// problems: https://leetcode.cn/problems/determine-if-string-halves-are-alike/
    /// date: 20221111
    /// </summary> 
    public static class Solution1704
    {
        public static bool HalvesAreAlike(string s) {
            var chars = new char[]{'a', 'e', 'i', 'o', 'u'};
            int length = s.Length;
            
            return s.Take(length / 2).Count(c => chars.Contains(char.ToLower(c)))
                == s.Skip(length / 2 ).Count(c => chars.Contains(char.ToLower(c)));
        }
    }
}