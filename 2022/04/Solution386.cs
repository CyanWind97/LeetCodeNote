using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 386
    /// title: 字典序排数
    /// problems: https://leetcode-cn.com/problems/lexicographical-numbers/
    /// date: 20220418
    /// </summary>
    public static class Solution386
    {
        public static IList<int> LexicalOrder(int n) {
            var result = new int[n];
            var index = 0;
            
            void Add(int left, int right){
                while(left <= right){
                    result[index++] = left;
                    Add(left * 10, Math.Min(left * 10 + 9, n));
                    left++;
                }
            }

            Add(1, Math.Min(9, n));

            return result;
        }

        // 参考解答
        public static IList<int> LexicalOrder_1(int n) {
            var ret = new int[n];
            int number = 1;
            for (int i = 0; i < n; i++) {
                ret[i] = number;
                if (number * 10 <= n) {
                    number *= 10;
                } else {
                    while (number % 10 == 9 || number >= n) {
                        number /= 10;
                    }
                    number++;
                }
            }
            return ret;
        }

    }
}