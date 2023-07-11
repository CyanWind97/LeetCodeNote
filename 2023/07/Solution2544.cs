using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2544
    /// title:  交替数字和
    /// problems: https://leetcode.cn/problems/alternating-digit-sum/
    /// date: 20230712
    /// </summary>
    public static class Solution2544
    {
        public static int AlternateDigitSum(int n) {
            int result = 0;
            bool isOdd = true;
            while(n > 0){
                int digit = n % 10;
                if(isOdd)
                    result += digit;
                else
                    result -= digit;
                
                isOdd = !isOdd;
                n /= 10;
            }

            var sign = isOdd ? 1 : -1;

            return sign * result;
        }
    }
}