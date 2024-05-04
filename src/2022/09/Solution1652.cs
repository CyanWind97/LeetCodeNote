using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1652
    /// title: 拆炸弹
    /// problems: https://leetcode.cn/problems/defuse-the-bomb/
    /// date: 20220924
    /// </summary>
    public static partial class Solution1652
    {
        public static int[] Decrypt(int[] code, int k) {
            int n = code.Length;
            var result = new int[n];
            if(k == 0)
                return result;
            
            int sign = Math.Sign(k);
            k *= sign;
            int sum = code.Take(k).Sum();
            if(sign > 0)
                result[n - 1] = sum;
            else
                result[k] = sum;
            
            for(int i = 1; i < n; i++){
                sum += code[(i + k - 1) % n] - code[i - 1];

                int j = sign > 0 ? i - 1 : (i + k) % n;
                result[j] = sum;
            }

            return result;
        }
    }
}