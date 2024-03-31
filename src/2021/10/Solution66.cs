using System;

namespace LeetCodeNote
{

    /// <summary>
    /// no: 66
    /// title: 加一
    /// problems: https://leetcode-cn.com/problems/plus-one/
    /// date: 20211021
    /// </summary>
    public static class Solution66
    {
        public static int[] PlusOne(int[] digits) {
            int length = digits.Length;
            int carry = 1;

            for(int i = length - 1; i >= 0 && carry == 1; i--){
                digits[i] = digits[i] + carry;
                if (digits[i] == 10)
                    digits[i] = 0;
                else
                    carry = 0;
            }

            if (digits[0] == 0){
                digits = new int[length + 1];
                digits[0] = 1;
            }

            return digits;
        }
    }
}