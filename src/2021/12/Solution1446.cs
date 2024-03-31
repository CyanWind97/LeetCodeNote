using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1446
    /// title:  连续字符
    /// problems: https://leetcode-cn.com/problems/consecutive-characters/
    /// date: 20211201
    /// </summary>
    public static class Solution1446
    {
        public static int MaxPower(string s) {
            int length = s.Length;
            int max = 1;
            int preIndex = 0;

            for(int i = 1; i < length; i++){
                if (s[i] != s[preIndex]){
                    max = Math.Max(max,  i - preIndex);
                    preIndex = i;
                }
            }

            return Math.Max(max, length - preIndex);
        }
    }
}