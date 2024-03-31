using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 72
    /// title:  编辑距离
    /// problems: https://leetcode.cn/problems/edit-distance/
    /// date: 20220513
    /// priority: 0043
    /// time: 00:03:31.76
    /// </summary>
    public static class CodeTop72
    {
        public static int MinDistance(string word1, string word2) {
            int m = word1.Length;
            int n = word2.Length;
            var edit = new int[m + 1, n + 1];
            
            for(int i = 0; i < m; i++){
                edit[i + 1, 0] = i + 1;
            }

            for(int j = 0; j < n; j++){
                edit[0, j + 1] = j + 1;
            }

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    edit[i + 1, j + 1] = word1[i] == word2[j]
                                        ? edit[i, j]
                                        : Math.Min(edit[i, j], Math.Min(edit[i, j + 1], edit[i + 1, j])) + 1;
                }
            }

            return edit[m, n];
        }
    }
}