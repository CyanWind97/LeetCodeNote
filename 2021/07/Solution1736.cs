using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1736
    /// title: 大餐计数
    /// problems: https://leetcode-cn.com/problems/latest-time-by-replacing-hidden-digits/
    /// date: 20210724
    /// </summary>
    public static class Solution1736
    {
        public static string MaximumTime(string time) {
            var chars = time.ToCharArray();
            if(chars[0] == '?')
                chars[0] = chars[1] == '?' || chars[1] <= '3' ? '2' : '1';
            
            if(chars[1] == '?')
                chars[1] = chars[0] == '2' ? '3' : '9';
            
            if(chars[3] == '?')
                chars[3] = '5';
            
            if(chars[4] == '?')
                chars[4] = '9';

            return new string(chars);
        }
    }
}