using System;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 482
    /// title: 密钥格式化
    /// problems: https://leetcode-cn.com/problems/license-key-formatting/
    /// date: 20211004
    /// </summary>
    public static class Solution482
    {
        public static string LicenseKeyFormatting(string s, int k) {
            var sb = new StringBuilder();
            int cnt = 0;

            for (int i = s.Length - 1; i >= 0; i --) {
                if (s[i] != '-') {
                    cnt++;
                    sb.Append(char.ToUpper(s[i]));
                    if (cnt % k == 0)
                        sb.Append("-");
                    
                }
            }

            if (sb.Length > 0 && sb[sb.Length - 1] == '-')
                sb.Remove(sb.Length - 1, 1);
            
            char[] cs = sb.ToString().ToCharArray();
            Array.Reverse(cs);
            return new string(cs);
        }
    }
}