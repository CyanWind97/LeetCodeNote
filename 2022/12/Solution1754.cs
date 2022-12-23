using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1754
    /// title: 构造字典序最大的合并字符串
    /// problems: https://leetcode.cn/problems/largest-merge-of-two-strings/
    /// date: 20221224
    /// </summary>
    public static class Solution1754
    {
        public static string LargestMerge(string word1, string word2) {
            var merge = new StringBuilder();
            int i = 0, j = 0;
            while (i < word1.Length || j < word2.Length) {
                if (i < word1.Length && word1.Substring(i).CompareTo(word2.Substring(j)) > 0) {
                    merge.Append(word1[i]);
                    i++;
                } else {
                    merge.Append(word2[j]);
                    j++;
                }
            }
            
            return merge.ToString();
        }
    }
}