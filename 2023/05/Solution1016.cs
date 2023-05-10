using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1016
    /// title: 子串能表示从 1 到 N 数字的二进制串
    /// problems: https://leetcode.cn/problems/binary-string-with-substrings-representing-1-to-n/
    /// date: 20230511
    /// </summary>
    public static class Solution1016
    {   
        // 参考解答
        // 滑动窗口
        // 若子串能包含[2^(k - 1), 2^k - 1]，则一定可以表示[1, 2^k - 1]
        // 所以求能否表达[2^(k - 1), 2^k - 1] 和 [2^k, n]就行
        public static bool QueryString(string s, int n) {
            if (n == 1) 
                return s.IndexOf('1') != -1;

            bool Help(int k, int mi, int ma) {
                var set = new HashSet<int>();
                int t = 0;
                for (int r = 0; r < s.Length; ++r) {
                    t = t * 2 + (s[r] - '0');
                    if (r >= k) 
                        t -= (s[r - k] - '0') << k;

                    if (r >= k - 1 && t >= mi && t <= ma) 
                        set.Add(t);
                    
                }
                return set.Count == ma - mi + 1;
            }

            int k = 30;
            while ((1 << k) >= n) {
                --k;
            }

            if (s.Length < (1 << (k - 1)) + k - 1 || s.Length < n - (1 << k) + k + 1) 
                return false;
            
            return Help(k, 1 << (k - 1), (1 << k) - 1) && Help(k + 1, 1 << k, n);
        }
    }
}