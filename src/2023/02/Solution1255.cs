using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1255
    /// title: 得分最高的单词集合
    /// problems: https://leetcode.cn/problems/maximum-score-words-formed-by-letters/
    /// date: 20230226
    /// </summary>
    public static class Solution1255
    {
        // 参考解答
        // 状态压缩
        public static int MaxScoreWords(string[] words, char[] letters, int[] score) {
            int n = words.Length, res = 0;
            int[] count = new int[26];
            foreach (char c in letters) {
                count[c - 'a']++;
            }
            for (int s = 1; s < (1 << n); s++) {
                int[] wordCount = new int[26]; // 统计子集 s 所有单词的字母数目
                for (int k = 0; k < n; k++) {
                    if ((s & (1 << k)) == 0) { // words[k] 不在子集 s 中
                        continue;
                    }
                    foreach (char c in words[k]) {
                        wordCount[c - 'a']++;
                    }
                }
                bool ok = true; // 判断子集 s 是否合法
                int sum = 0; // 保存子集 s 的得分
                for (int i = 0; i < 26; i++) {
                    sum += score[i] * wordCount[i];
                    ok = ok && (wordCount[i] <= count[i]);
                }
                if (ok) {
                    res = Math.Max(res, sum);
                }
            }
            return res;
        }
    }
}