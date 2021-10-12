using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 29
    /// title: 两数相除
    /// problems: https://leetcode-cn.com/problems/divide-two-integers/
    /// date: 20211012
    /// </summary>
    public static class Solution29
    {
        // 参考解答 类二分法 快乘法
        public static int Divide(int dividend, int divisor) {
            // 考虑被除数为最小值的情况
            if (dividend == int.MinValue) {
                if (divisor == 1) 
                    return int.MinValue;

                if (divisor == -1) 
                    return int.MaxValue;
            }
        
            // 考虑除数为最小值的情况
            if (divisor == int.MinValue) 
                return dividend == int.MinValue ? 1 : 0;
            
            // 考虑被除数为 0 的情况
            if (dividend == 0) 
                return 0;
            
            // 一般情况，使用类二分查找
            // 将所有的正数取相反数，这样就只需要考虑一种情况
            bool rev = false;
            if (dividend > 0) {
                dividend = -dividend;
                rev = !rev;
            }
            
            if (divisor > 0) {
                divisor = -divisor;
                rev = !rev;
            }

            IList<int> candidates = new List<int>();
            candidates.Add(divisor);
            int index = 0;
            // 注意溢出
            while (candidates[index] >= dividend - candidates[index]) {
                candidates.Add(candidates[index] + candidates[index]);
                ++index;
            }

            int ans = 0;
            for (int i = candidates.Count - 1; i >= 0; --i) {
                if (candidates[i] >= dividend) {
                    ans += 1 << i;
                    dividend -= candidates[i];
                }
            }

            return rev ? -ans : ans;
        }
    }
}