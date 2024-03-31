using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2180
    /// title: 统计各位数字之和为偶数的整数个数
    /// problems: https://leetcode.cn/problems/count-integers-with-even-digit-sum/
    /// date: 20230106
    /// </summary>
    public static class Solution2180
    {
        public static int CountEven(int num) {
            int y = num / 10;
            int x = num % 10;
            int result = y * 5;
            int ySum = 0;
            while(y != 0){
                ySum += y % 10;
                y /= 10;
            }

            if(ySum % 2 == 0)
                result += x / 2 + 1;
            else
                result += (x + 1) / 2;

            return result - 1;
        }
    }
}