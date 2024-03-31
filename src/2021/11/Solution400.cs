using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 400
    /// title:  第 N 位数字
    /// problems: https://leetcode-cn.com/problems/nth-digit/
    /// date: 20211130
    /// </summary>
    public static class Solution400
    {
        public static int FindNthDigit(int n) {
            int count = 1;
            int start = 1;

            while(true){
                if (count != 1)
                    start *= 10;
                
                long totals = (long)count * 9 * start;
                if (n <=  totals)
                    break;
                
                n -= (int)totals;
                count++;
            }

            int num = start + (n - 1) / count;
            int mod = (n - 1) % count;

            for(int i = 0; i < count - mod - 1; i++){
                num /= 10;
            }

            return num % 10;
        }
    }
}