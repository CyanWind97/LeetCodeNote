using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2303
    /// title: 计算应缴税款总额
    /// problems: https://leetcode.cn/problems/calculate-amount-paid-in-taxes/
    /// date: 20230123
    /// </summary>
    public static class Solution2303
    {
        public static double CalculateTax(int[][] brackets, int income) {
            double tax = 0;
            int prev = 0;
            foreach(var bracket in brackets){
                if(income < bracket[0]){
                    tax += (double)(income - prev) * bracket[1] / 100;
                    break;
                }
                
                tax += (double)(bracket[0] - prev) * bracket[1] / 100;
                prev = bracket[0];
            }

            return tax;
        }
    }
}