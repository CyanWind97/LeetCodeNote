using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1668
    /// title: 最大重复子字符串
    /// problems: https://leetcode.cn/problems/maximum-repeating-substring/
    /// date: 20221103
    /// </summary> 
    public static class Solution1668
    {
        public static int MaxRepeating(string sequence, string word) {
            int n = sequence.Length;
            int m = word.Length;

            if(n < m)
                return 0;
            
            int[] fail = new int[m];
            Array.Fill(fail, -1);
            int j;
            for (int i = 1; i < m; ++i) {
                j = fail[i - 1];
                while (j != -1 && word[j + 1] != word[i]) {
                    j = fail[j];
                }
                if (word[j + 1] == word[i]) {
                    fail[i] = j + 1;
                }
            }

            int[] f = new int[n];
            j = -1;
            for (int i = 0; i < n; ++i) {
                while (j != -1 && word[j + 1] != sequence[i]) {
                    j = fail[j];
                }
                if (word[j + 1] == sequence[i]) {
                    ++j;
                    if (j == m - 1) {
                        f[i] = (i >= m ? f[i - m] : 0) + 1;
                        j = fail[j];
                    }
                }
            }

            return f.Max();
        }
    }
}