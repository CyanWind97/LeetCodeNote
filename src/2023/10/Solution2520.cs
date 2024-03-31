using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2520
    /// title: 统计能整除数字的位数
    /// problems: https://leetcode.cn/problems/count-the-digits-that-divide-a-number/?envType=daily-question&envId=2023-10-26
    /// date: 20231026
    /// </summary>
    public static class Solution2520
    {
        public static int CountDigits(int num) {
            int t = num;
            int result = 0;
            while (t != 0) {
                if (num % (t % 10) == 0) 
                    result++;
                
                t /= 10;
            }
            
            return result;
        }
    }
}