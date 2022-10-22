using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1768
    /// title:  交替合并字符串
    /// problems: https://leetcode.cn/problems/merge-strings-alternately/
    /// date: 20221023
    /// </summary>
    public static class Solution1768
    {
        public static string MergeAlternately(string word1, string word2) {
            int l1 = word1.Length;
            int l2 = word2.Length;
            int l = Math.Min(l1, l2);

            var result = new char[l1 + l2];
            
            for(int i = 0; i < l; i++){
                result[2 * i] = word1[i];
                result[2 * i + 1] = word2[i];
            }

            for(int i = l; i < l1; i++){
                result[l + i] = word1[i];
            }

            for(int i = l; i < l2; i++){
                result[l + i] = word2[i];
            }

            return new string(result);
        }
    }
}