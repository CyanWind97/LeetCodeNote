using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 748
    /// title:  最短补全词
    /// problems: https://leetcode-cn.com/problems/shortest-completing-word/
    /// date: 20211210
    /// </summary>
    public static class Solution748
    {
        public static string ShortestCompletingWord(string licensePlate, string[] words) {
            int[] count = new int[26];

            foreach(var c in licensePlate){
                if (!char.IsLetter(c))
                    continue;
                
                count[char.ToLower(c) - 'a']++;
            }

            int minLength = int.MaxValue;
            string result = licensePlate;

            foreach(var word in words){
                int length = word.Length;
                if (minLength <= length)
                    continue;

                var copy = new int[26];
                count.CopyTo(copy, 0);

                foreach(var c in word){
                    copy[c - 'a']--;
                }

                if(copy.Any(x => x > 0))
                    continue;

                result = word;
                minLength = length;
            }
            
            return result;
        }
    }
}