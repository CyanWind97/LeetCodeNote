using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 926
    /// title: 将字符串翻转到单调递增
    /// problems: https://leetcode.cn/problems/flip-string-to-monotone-increasing/
    /// date: 20220611
    /// </summary>
    public static class Solution926
    {
        public static int MinFlipsMonoIncr(string s) {
            int length = s.Length;
            int dp0 = 0;
            int dp1 = 0;

            for(int i = 0; i < length; i++){
                char c = s[i];
                int dp0New = dp0;
                int dp1New = Math.Min(dp0, dp1);
                if(c == '1')
                    dp0New++;
                else
                    dp1New++;
                
                dp0 = dp0New;
                dp1 = dp1New;
            }

            return Math.Min(dp0, dp1);
        }
    }
}