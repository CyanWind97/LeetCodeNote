using System;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1624
    /// title: 两个相同字符之间的最长子字符串
    /// problems: https://leetcode.cn/problems/largest-substring-between-two-equal-characters/
    /// date: 20220917
    /// </summary>
    public static class Solution1624
    {
        public static int MaxLengthBetweenEqualCharacters(string s) {
            int[] mark = new int[26];
            Array.Fill(mark, -1);

            int max = -1;
            for (int i = 0; i < s.Length; i++) {
                int index = s[i] - 'a';
                if (mark[index] < 0)
                    mark[index] = i;
                else
                    max = Math.Max(max, i - mark[index] - 1);
            }

            return max;
        }
    }
}