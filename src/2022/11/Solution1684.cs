using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1684
    /// title: 统计一致字符串的数目
    /// problems: https://leetcode.cn/problems/count-the-number-of-consistent-strings/
    /// date: 20221108
    /// </summary> 
    public static class Solution1684
    {
        public static int CountConsistentStrings(string allowed, string[] words) {
            var consistents = new bool[26];
            foreach(var c in allowed){
                consistents[c - 'a'] = true;
            }

            return words.Count(word => word.All(c => consistents[c - 'a']));
        }
    }
}