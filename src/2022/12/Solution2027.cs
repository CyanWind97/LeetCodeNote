using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2027
    /// title: 转换字符串的最少操作次数
    /// problems: https://leetcode.cn/problems/minimum-moves-to-convert-string/
    /// date: 20221227
    /// </summary>
    public static class Solution2027
    {
        public static int MinimumMoves(string s) {
            int covered = -1, res = 0;
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == 'X' && i > covered) {
                    res++;
                    covered = i + 2;
                }
            }
            
            return res;
        }
    }
}