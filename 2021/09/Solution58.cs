using System.Text.RegularExpressions;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 58
    /// title: 最后一个单词的长度
    /// problems: https://leetcode-cn.com/problems/length-of-last-word/
    /// date: 20210921
    /// </summary>
    public static class Solution58
    {
        public static int LengthOfLastWord(string s) {
            int legnth = s.Length;
            
            int i = legnth - 1;
            while(i >= 0 && s[i] == ' '){
                i--;
            }

            var end = i;
            while(i >= 0 && s[i] != ' '){
                i--;
            }
            
            return end - i;
        }
    }
}