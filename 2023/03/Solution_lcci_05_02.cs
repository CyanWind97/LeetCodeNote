using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 05.02
    /// title: 二进制数转字符串
    /// problems: https://leetcode.cn/problems/bianry-number-to-string-lcci/
    /// date: 20230302
    /// type: 面试题 lcci
    /// </summary>
    public static class Solution_lcci_05_02
    {
        // 参考解答
        public static string PrintBin(double num) {
            var builder = new StringBuilder("0.");
            while(builder.Length <= 32 && num != 0){
                num *= 2;
                int digit = (int)num;
                builder.Append(digit);
                num -= digit;
            }

            return builder.Length <= 32 ? builder.ToString() : "ERROR";
        }
    }
}