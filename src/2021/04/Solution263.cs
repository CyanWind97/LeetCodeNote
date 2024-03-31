using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 263
    /// title: 丑数
    /// problems: https://leetcode-cn.com/problems/ugly-number/
    /// date: 20210410
    /// </summary>
    public static class Solution263
    {
        public static bool IsUgly(int n) {
            if(n <= 0)
                return false;
            
            if(n == 1 || n == 2 || n == 3 || n == 5)
                return true;
            
            if(n % 2 == 0)
                return IsUgly(n / 2);
            
            if(n % 3 == 0)
                return IsUgly(n / 3);

            if(n % 5 == 0)
                return IsUgly(n / 5);

            return false;
        }

        // 参考解答
        public static bool IsUgly_1(int n) {
            if(n <= 0)
                return false;
            
            int[] factors = {2, 3, 5};
            foreach(int factor in factors) {
                while (n % factor == 0) {
                    n /= factor;
                }
            }
            return n == 1;
        }
    }
}