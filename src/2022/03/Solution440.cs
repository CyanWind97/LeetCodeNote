using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 440
    /// title: 字典序的第K小数字
    /// problems: https://leetcode-cn.com/problems/k-th-smallest-in-lexicographical-order/
    /// date: 20220323
    /// </summary>
    public static class Solution440
    {
        // 参考解答 字典树
        public static int FindKthNumber(int n, int k) {
            int GetSteps(int curr) {
                long steps = 0;
                long first = curr;
                long last = curr;
                while (first <= n) {
                    steps += Math.Min(last, n) - first + 1;
                    first = first * 10;
                    last = last * 10 + 9;
                }
                
                return (int) steps;
            }

            int curr = 1;
            k--;
            
            while (k > 0) {
                int steps = GetSteps(curr);
                if (steps <= k) {
                    k -= steps;
                    curr++;
                } else {
                    curr = curr * 10;
                    k--;
                }
            }
            return curr;
        }

    }
}