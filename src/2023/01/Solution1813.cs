using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2293
    /// title: 句子相似性 III
    /// problems: https://leetcode.cn/problems/sentence-similarity-iii/
    /// date: 20230116
    /// </summary>
    public static class Solution1813
    {   
        // 参考解答
        public static bool AreSentencesSimilar(string sentence1, string sentence2) {
            var words1 = sentence1.Split(" ");
            var words2 = sentence2.Split(" ");

            int l1 = words1.Length;
            int l2 = words2.Length;

            int i = 0;
            int j = 0;

            while(i < l1 && i < l2 && words1[i] == words2[i]){
                i++;
            }

            while(j < l1 - i && j < l2 - i && words1[l1 - j - 1] == words2[l2 - j - 1]){
                j++;
            }

            return i + j == Math.Min(l1, l2);
        }   
    }
}