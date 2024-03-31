using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1422
    /// title:  分割字符串的最大得分
    /// problems: https://leetcode.cn/problems/maximum-score-after-splitting-a-string/
    /// date: 20220814
    /// </summary>
    public static class Solution1422
    {
        public static int MaxScore(string s) {
            int score = 0;
            int length = s.Length;
            if (s[0] == '0') 
                score++;
            
            score += s.Skip(1).Count(c => c == '1');

            int max = score;
            for (int i = 1; i < length - 1; i++) {
                if (s[i] == '0')
                    score++;
                else
                    score--;
                
                max = Math.Max(max, score);
            }

            return max;
        }
    }
}