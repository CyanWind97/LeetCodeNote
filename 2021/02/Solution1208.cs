using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    public static class Solution1208
    {
        /// <summary>
        /// no: 1208
        /// title: 尽可能使字符串相等
        /// problems: https://leetcode-cn.com/problems/get-equal-substrings-within-budget/
        /// date: 20210205
        /// </summary>
        public static int EqualSubstring(string s, string t, int maxCost) {
            char[] charsS = s.ToCharArray();
            char[] charsT = t.ToCharArray();
            int length = charsS.Length;
            int left = 0; int right = 0;
            int cost = 0;
            while(right < length){
                cost += Math.Abs(charsS[right] - charsT[right]);
                right++;
                if(cost > maxCost){
                    cost -= Math.Abs(charsS[left] - charsT[left]);
                    left++;
                }
            }

            return right - left;
        }
    }
}