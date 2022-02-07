using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2000
    /// title:  反转单词前缀
    /// problems: https://leetcode-cn.com/problems/reverse-prefix-of-word/
    /// date: 20220202
    /// </summary>
    public static class Solution2000
    {
        public static string ReversePrefix(string word, char ch) {
            int index = word.IndexOf(ch);
            if(index < 0)
                return word;
            
            var chars = word.ToCharArray();

            Array.Reverse(chars, 0, index + 1);

            return new string(chars);
        }
    }
}