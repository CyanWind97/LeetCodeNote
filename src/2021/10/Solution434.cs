using System.Text.RegularExpressions;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 434
    /// title: 字符串中的单词数
    /// problems: https://leetcode-cn.com/problems/number-of-segments-in-a-string/
    /// date: 20211007
    /// </summary>
    public static class Solution434
    {
        public static int CountSegments(string s) {
            int count = 0;
            int length = s.Length;
            for(int i = 0; i < length; i++){
                if((i == 0 || s[i - 1] == ' ') && s[i] != ' ')
                    count++;
            }

            return count;
        }
    }
}