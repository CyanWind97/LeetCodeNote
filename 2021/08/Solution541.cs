using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 551
    /// title: 反转字符串 II
    /// problems: https://leetcode-cn.com/problems/reverse-string-ii/
    /// date: 20210820
    /// </summary>

    public static class Solution541
    {
        public static string ReverseStr(string s, int k) {
            char[] chars = s.ToCharArray();
            int length = s.Length;
            for(int i = 0; i * k < length; i += 2){
                int left = i * k;
                int right = Math.Min((i + 1) * k, length) - 1;
                
                while(left < right){
                    (chars[left], chars[right]) = (chars[right], chars[left]);
                    left++;
                    right--;
                }
            }

            return new string(chars);
        }
    }
}