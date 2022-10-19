using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 779
    /// title: 第K个语法符号
    /// problems: https://leetcode.cn/problems/k-th-symbol-in-grammar/
    /// date: 20221020
    /// </summary>
    public static class Solution779
    {
        public static int KthGrammar(int n, int k) {
            int GetK(int p, int l, int d){
                if(l <= 2)
                    return d - 1;
                
                if(2 * d > l )
                    return (p % 2 == 0 ? 1 : 0)  ^ GetK(p - 1, l / 2, l + 1 - d);
                else
                    return GetK(p - 1, l / 2, d);
            }
        
            return GetK(n, (int)Math.Pow(2, n - 1), k);
        }

        // 参考解答
        public static int KthGrammar_1(int n, int k) {
            k--;
            int res = 0;
            while (k > 0) {
                k &= k - 1;
                res ^= 1;
            }
            
            return res;
        }
    }
}