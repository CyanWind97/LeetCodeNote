using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1638
    /// title: 统计只差一个字符的子串数目
    /// problems: https://leetcode.cn/problems/count-substrings-that-differ-by-one-character/
    /// date: 20230327
    /// </summary>
    public static class Solution1638
    {
        // 参考解答
        // dp
        public static int CountSubstrings(string s, string t) {
            int m = s.Length, n = t.Length;
            var dpl = new int[m + 1, n + 1];
            var dpr = new int[m + 1, n + 1];

            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    dpl[i + 1, j + 1] = s[i] == t[j] ? (dpl[i, j] + 1) : 0;
                }
            }
            for (int i = m - 1; i >= 0; i--) {
                for (int j = n - 1; j >= 0; j--) {
                    dpr[i, j] = s[i] == t[j] ? (dpr[i + 1, j + 1] + 1) : 0;
                }
            }
            int ans = 0;
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    if (s[i] != t[j]) 
                        ans += (dpl[i, j] + 1) * (dpr[i + 1, j + 1] + 1);
                }
            }
            
            return ans;
        }
    }
}