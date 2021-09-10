using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1894
    /// title: 找到需要补充粉笔的学生编号
    /// problems: https://leetcode-cn.com/problems/find-the-student-that-will-replace-the-chalk/
    /// date: 20210910
    /// </summary>
    public static class Solution1894
    {
        public static int ChalkReplacer(int[] chalk, int k) {
            int n = chalk.Length;
            long total = 0;
            foreach (int num in chalk) {
                total += num;
            }
            if (k >= total) {
                k %= (int) total;
            }
            int res = -1;
            for (int i = 0; i < n; ++i) {
                if (chalk[i] > k) {
                    res = i;
                    break;
                }
                k -= chalk[i];
            }
            return res;
            }
    }
}