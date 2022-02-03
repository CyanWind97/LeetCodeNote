using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1414
    /// title: 为 K 的最少斐波那契数字数目
    /// problems: https://leetcode-cn.com/problems/find-the-minimum-number-of-fibonacci-numbers-whose-sum-is-k/
    /// date: 20220203
    /// </summary>
    public static class Solution1414
    {
        public static int FindMinFibonacciNumbers(int k) {
            var f = new List<int>();
            f.Add(1);

            int a = 1, b = 1;
            while (a + b <= k) {
                int c = a + b;
                f.Add(c);
                a = b;
                b = c;
            }

            int result = 0;
            for (int i = f.Count - 1; i >= 0 && k > 0; i--) {
                int num = f[i];
                if (k >= num) {
                    k -= num;
                    result++;
                }
            }

            return result;
        }
    }
}