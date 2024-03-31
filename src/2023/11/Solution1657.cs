using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1657
    /// title: 确定两个字符串是否接近
    /// problems: https://leetcode.cn/problems/determine-if-two-strings-are-close/description/?envType=daily-question&envId=2023-11-30
    /// date: 20231130
    /// </summary>
    public static class Solution1657
    {
        public static bool CloseStrings(string word1, string word2) {
            if(word1.Length != word2.Length)
                return false;
            
            int[] count1 = new int[26];
            int[] count2 = new int[26];
            foreach(var c in word1)
                count1[c - 'a']++;
            
            foreach(var c in word2)
                count2[c - 'a']++;
            
            for(int i = 0; i < 26; i++){
                if((count1[i] == 0) != (count2[i] == 0))
                    return false;
            }

            Array.Sort(count1);
            Array.Sort(count2);
            
            return count1.SequenceEqual(count2);
        }
    }
}