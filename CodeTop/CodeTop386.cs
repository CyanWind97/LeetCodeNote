using System;
using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 386
    /// title: 字典序排数
    /// problems: https://leetcode.cn/problems/lexicographical-numbers/
    /// date: 20220516
    /// priority: 0071
    /// time: 00:08:23.65
    /// </summary>
    public static class CodeTop386
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
    }
}