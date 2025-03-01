using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 132
    /// title: 分割回文串 II
    /// problems: https://leetcode-cn.com/problems/palindrome-partitioning-ii/
    /// date: 20210308
    /// </summary>
    public static partial class Solution132
    {
        public static int MinCut(string s) {
            int length = s.Length;
            bool[,] g = new bool[length, length];

            for(int i = 0; i < length; i++){
                for(int j = 0; j < length; j++){
                    g[i, j] = true;
                }
            }

            for (int i = length - 1; i >= 0; --i) {
                for (int j = i + 1; j < length; ++j) {
                    g[i, j] = s[i] == s[j] && g[i + 1 , j - 1];
                }
            }

            int[] f = new int[length];
            Array.Fill(f, int.MaxValue);
            for (int i = 0; i < length; ++i) {
                if (g[0, i]) {
                    f[i] = 0;
                } else {
                    for (int j = 0; j < i; ++j) {
                        if (g[j + 1 , i]) {
                            f[i] = Math.Min(f[i], f[j] + 1);
                        }
                    }
                }
            }

            return f[length - 1];

        }
    }
}