using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1239
    /// title:  串联字符串的最大长度
    /// problems: https://leetcode-cn.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/
    /// date: 20210619
    /// </summary>
    public static class Solution1239
    {
        // 参考 迭代 + 位运算
        public static int MaxLength(IList<string> arr) {
            int ans = 0;
            IList<int> masks = new List<int>();
            masks.Add(0);
            foreach (string s in arr) {
                int mask = 0;
                foreach (char c in s) {
                    int ch = c - 'a';
                    if (((mask >> ch) & 1) != 0) { // 若 mask 已有 ch，则说明 s 含有重复字母，无法构成可行解
                        mask = 0;
                        break;
                    }
                    mask |= 1 << ch; // 将 ch 加入 mask 中
                }
                if (mask == 0) {
                    continue;
                }
                int n = masks.Count;
                for (int i = 0; i < n; ++i) {
                    int m = masks[i];
                    if ((m & mask) == 0) { // m 和 mask 无公共元素
                        masks.Add(m | mask);
                        ans = Math.Max(ans, BitCount(m | mask));
                    }
                }
            }
            return ans;
        }

        private static int BitCount(int i) {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            i = (i + (i >> 4)) & 0x0f0f0f0f;
            i = i + (i >> 8);
            i = i + (i >> 16);
            return i & 0x3f;
        }
    }
}
