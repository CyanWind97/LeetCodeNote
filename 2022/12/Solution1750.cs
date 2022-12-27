using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1750
    /// title: 删除字符串两端相同字符后的最短长度
    /// problems: https://leetcode.cn/problems/minimum-length-of-string-after-deleting-similar-ends/
    /// date: 20221228
    /// </summary>
    public static class Solution1750
    {
        public static int MinimumLength(string s) {
            int n = s.Length;
            int left = 0, right = n - 1;
            while (left < right && s[left] == s[right]) {
                char c = s[left];
                while (left <= right && s[left] == c) {
                    left++;
                }
                while (left <= right && s[right] == c) {
                    right--;
                }
            }
            
            return right - left + 1;
        }
    }
}