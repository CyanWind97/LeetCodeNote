using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1822
    /// title: 数组元素积的符号
    /// problems: https://leetcode.cn/problems/sign-of-the-product-of-an-array/
    /// date: 20221027
    /// </summary>
    public static class Solution1822
    {
        public static int ArraySign(int[] nums) {
            return nums.Aggregate(1, (product, num) => product * Math.Sign(num));
        }
    }
}