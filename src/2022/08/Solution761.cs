using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 761
    /// title:  特殊的二进制序列
    /// problems: https://leetcode.cn/problems/special-binary-string/
    /// date: 20220808
    /// </summary>
    public static class Solution761
    {
        // 参考解答
        // 没看懂题目
        public static string MakeLargestSpecial(string s) {
            if (s.Length <= 2)
                return s;
            
            int cnt = 0, left = 0;
            var subs = new List<string>();
            for (int i = 0; i < s.Length; ++i) {
                if (s[i] == '1') {
                    ++cnt;
                } else {
                    --cnt;
                    if (cnt == 0) {
                        subs.Add("1" + MakeLargestSpecial(s.Substring(left + 1, i - left - 1)) + "0");
                        left = i + 1;
                    }
                }
            }

            subs.Sort((a, b) => b.CompareTo(a));

            return string.Join("", subs);
        }
    }
}