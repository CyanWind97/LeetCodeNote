using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1945
    /// title:  字符串转化后的各位数字之和
    /// problems: https://leetcode.cn/problems/sum-of-digits-of-string-after-convert/
    /// date: 20221215
    /// </summary>
    public static class Solution1945
    {
        public static int GetLucky(string s, int k) {
            var sb = new StringBuilder();
            foreach (char ch in s) {
                sb.Append(ch - 'a' + 1);
            }

            var digits = sb.ToString();
            for (int i = 1; i <= k && digits.Length > 1; ++i) {
                int sum = 0;
                foreach (char ch in digits) {
                    sum += ch - '0';
                }
                
                digits = sum.ToString();
            }

            return int.Parse(digits);
        }
    }
}