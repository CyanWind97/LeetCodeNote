using System;
using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 3
    /// title:  无重复字符的最长子串
    /// problems: https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/
    /// date: 20220505
    /// priority: 0008
    /// time: 00:10:48.19
    public static class CodeTop3
    {
        public static int LengthOfLongestSubstring(string s) {
            int length = s.Length;
            int left = 0;
            int right = left;
            int result = 0;

            var visited = new HashSet<char>();

            while(right < length){
                while(right < length && visited.Add(s[right])){
                    right++;
                }

                result = Math.Max(right - left, result);
                if(right == length)
                    break;

                while(left < right && s[left] != s[right]){
                    visited.Remove(s[left]);
                    left++;
                }

                visited.Remove(s[left]);
                left++;
            }

            return result;
        }
    }
}