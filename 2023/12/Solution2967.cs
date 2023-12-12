using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2967
    /// title: 字典序最小回文串
    /// problems: https://leetcode.cn/problems/lexicographically-smallest-palindrome/description/?envType=daily-question&envId=2023-12-13
    /// date: 20231213
    /// </summary>
    public static class Solution2967
    {
        public static string MakeSmallestPalindrome(string s) {
            int length = s.Length;
            var chars = s.ToArray();
            
            for(int i = 0; i < length / 2; i++){
                if(chars[i] == chars[^(i + 1)])
                    continue;
                
                if(chars[i] < chars[^(i + 1)])
                    chars[^(i + 1)] = chars[i];
                else
                    chars[i] = chars[^(i + 1)];
            }

            return new string(chars);
        }
    }
}