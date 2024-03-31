using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 414
    /// title: 第三大的数
    /// problems: https://leetcode-cn.com/problems/third-maximum-number/
    /// date: 20211006
    /// </summary>
    public static class Solution414
    {
        public static int ThirdMax(int[] nums) {
            int? a = null, b = null, c = null;
            foreach (int num in nums) {
                if (a == null || num > a) {
                    c = b;
                    b = a;
                    a = num;
                } else if (a > num && (b == null || num > b)) {
                    c = b;
                    b = num;
                } else if (b != null && b > num && (c == null || num > c)) {
                    c = num;
                }
            }
            
            return c ?? a.Value;
        }
    }
}