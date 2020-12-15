using System;
using System.Text.RegularExpressions;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 738
    /// title: 单调递增的数字
    /// problems: https://leetcode-cn.com/problems/monotone-increasing-digits/
    /// date: 20201215
    /// </summary>
    public static class Solution738
    {
        public static int MonotoneIncreasingDigits(int N) {
            int preNum = 9;
            int result = N;
            int len = 0;
            while( N > 0) {
                int num =  N % 10;
                if(num > preNum) {
                    result = N *  (int)Math.Pow(10, len) - 1;
                    num -= 1;
                }
                len++;
                preNum = num;
                N = N / 10;
            }

            return result;
        }

        // 参考解答：数学 累加法
        public static int MonotoneIncreasingDigits_1(int N) {
            int ones = 111111111;
            int result = 0;
            for(int i = 0; i < 9; i ++) {
                while( result + ones > N) {
                    ones /= 10;
                }
                result += ones;
            }

            return result;
        }

        // 改进 不必调用Math.Pow函数
        public static int MonotoneIncreasingDigits_2(int N) {
            int preNum = 9;
            int i = 1;
            while( i <= N) {
                int num =  N / i % 10;
                if(num > preNum) {
                    N = N / i * i - 1;
                    num -= 1;
                }
                i *= 10;
                preNum = num;
            }

            return N;
        }
    }
}