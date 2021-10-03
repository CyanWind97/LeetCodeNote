using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 166
    /// title: 分数到小数
    /// problems: https://leetcode-cn.com/problems/fraction-to-recurring-decimal/
    /// date: 20211003
    /// </summary>
    public static class Solution166
    {
        // 参考解答 长除法
        public static string FractionToDecimal(int numerator, int denominator) {
            long lNumerator = (long)numerator;
            long lDenominator = (long)denominator;

            if (lNumerator % lDenominator == 0)
                return (lNumerator / lDenominator).ToString();
            
            var sb = new StringBuilder();
            if (lNumerator < 0 ^ lDenominator < 0)
                sb.Append('-');
            
            
            lNumerator = Math.Abs(lNumerator);
            lDenominator = Math.Abs(lDenominator);

            #region 整数部分
            long intPart = lNumerator / lDenominator;
            sb.Append(intPart);
            sb.Append('.');
            #endregion

            #region 小数部分
            var fractionPart = new StringBuilder();
            var dic = new Dictionary<long, int>();
            long remainder = lNumerator % lDenominator;
            int index = 0;
            while(remainder != 0 && !dic.ContainsKey(remainder)){
                dic.Add(remainder, index);
                remainder *= 10;
                fractionPart.Append(remainder / lDenominator);
                remainder %= denominator;
                index++;
            }

            if (remainder != 0 ){
                int insertIndex = dic[remainder];
                fractionPart.Insert(insertIndex, '(');
                fractionPart.Append(')');
            }

            sb.Append(fractionPart.ToString());

            #endregion

            return sb.ToString();
        }
    }
}