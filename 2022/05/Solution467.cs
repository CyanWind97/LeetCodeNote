using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 467
    /// title: 环绕字符串中唯一的子字符串
    /// problems: https://leetcode.cn/problems/unique-substrings-in-wraparound-string/
    /// date: 20220525
    /// </summary>  
    public static class Solution467
    {
        // 参考解答 看不懂题目
        public static int FindSubstringInWraproundString(string p) {
            int[] dp = new int[26];
            int k = 0;
            int length = p.Length;
            for(int i = 0; i < length; i++){
                if(i > 0 && (p[i] - p[i - 1] + 26) % 26 == 1)
                    k++;
                else
                    k = 1;
                
                dp[p[i] - 'a'] = Math.Max(dp[p[i] - 'a'], k);
            }

            return dp.Sum();
        }
    }
}