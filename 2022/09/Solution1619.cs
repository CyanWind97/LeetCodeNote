using System;
using System.Linq;

namespace LeetCodeNote
{
    // <summary>
    /// no: 1619
    /// title: 删除某些元素后的数组均值
    /// problems: https://leetcode.cn/problems/mean-of-array-after-removing-some-elements/
    /// date: 20220914
    /// </summary>
    public static class Solution1619
    {
        public static double TrimMean(int[] arr) {
            int length = arr.Length;
            Array.Sort(arr);
            
            int k = length / 20;

            return arr.Skip(k).SkipLast(k).Average();
        }
    }
}