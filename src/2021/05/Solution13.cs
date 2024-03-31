using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 13
    /// title: 罗马数字转整数
    /// problems: https://leetcode-cn.com/problems/roman-to-integer/
    /// date: 20210515
    /// </summary>
    public static class Solution13
    {
        public static int RomanToInt(string s) {
            Dictionary<char, int> dic = new Dictionary<char, int>() {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            int result = 0;
            int length = s.Length;
            for(int i = 0; i < length; i++){
                int value = dic[s[i]];
                if(i < length - 1 && value < dic[s[i + 1]])
                    result -= value;
                else
                    result += value;
            }

            return result;
        }
    }
}