using System;
using System.Text.RegularExpressions;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 151
    /// title:   颠倒字符串中的单词
    /// problems: https://leetcode-cn.com/problems/reverse-words-in-a-string/
    /// date: 20220507
    /// priority: 0016
    /// time: 00:02:44.83
    /// </summary>
    public static class CodeTop151
    {
        public static string ReverseWords(string s) {
            var words = Regex.Split(s.Trim(), @"\s+");

            Array.Reverse(words);
            
            return string.Join(" ", words);
        }
    }
}