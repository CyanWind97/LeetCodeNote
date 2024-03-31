using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1576
    /// title: 替换所有的问号
    /// problems: https://leetcode-cn.com/problems/replace-all-s-to-avoid-consecutive-repeating-characters/
    /// date: 20220105
    /// </summary>
    public static class Solution1576
    {
        public static string ModifyString(string s) {
            int length = s.Length;
            char[] chars = s.ToCharArray();
            var options = new char[]{'a', 'b', 'c'};

            for (int i = 0; i < length; ++i) {
                if (chars[i] == '?') 
                    chars[i] = options.First(ch => !((i > 0 && chars[i - 1] == ch) || (i < length - 1 && chars[i + 1] == ch)));
                
            }

            return new string(chars);
        }
    }
}