 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1653
    /// title: 使字符串平衡的最少删除次数
    /// problems: https://leetcode.cn/problems/minimum-deletions-to-make-string-balanced/
    /// date: 20230306
    /// </summary>
    public static class Solution1653
    {
        public static int MinimumDeletions(string s) {
            int length = s.Length;
            var count = new int[length + 1];
            for(int i = 0; i < length; i++){
                count[i + 1] = count[i] + (s[i] == 'a' ? 1 : 0);
            }

            int result = length;
            for(int i = 0; i < length; i++){
                int delA = count[length + 1] - count[i + 1];
                int delB = i - count[i];
                result = Math.Min(delA + delB, result);
            }

            return result;
        }

        // 参考解答
        public static int MinimumDeletions_1(string s) {
            int leftb = 0, righta = 0;
            foreach (char c in s) {
                if (c == 'a') {
                    righta++;
                }
            }
            int res = righta;
            foreach (char c in s) {
                if (c == 'a') {
                    righta--;
                } else {
                    leftb++;
                }
                res = Math.Min(res, leftb + righta);
            }
            return res;
        }
    }
}