using System;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 504
    /// title: 七进制数
    /// problems: https://leetcode-cn.com/problems/base-7/
    /// date: 20220307
    /// </summary>
    public static class Solution504
    {
        public static string ConvertToBase7(int num) {
            if(num == 0)
                return "0";

            var sb = new StringBuilder();
            bool isNegative  = num < 0;
            if(isNegative)
                num = -num;

            while(num > 0){
                sb.Insert(0, num % 7);
                num /= 7;
            }

            if(isNegative)
                sb.Insert(0, '-');
            
            return sb.ToString();
        }
    }
}