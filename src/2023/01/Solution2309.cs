using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2309
    /// title: 兼具大小写的最好英文字母
    /// problems: https://leetcode.cn/problems/greatest-english-letter-in-upper-and-lower-case/
    /// date: 20230127
    /// </summary>
    public static class Solution2309
    {
        public static string GreatestLetter(string s) {
            var set = new HashSet<char>();
            foreach(var c in s){
                set.Add(c);
            }

            for (int i = 25; i >= 0; i--) {
                if (set.Contains((char) ('a' + i)) && set.Contains((char) ('A' + i)))
                    return ((char) ('A' + i)).ToString();
            }

            return "";
        }
    }
}