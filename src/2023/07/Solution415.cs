using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 415
    /// title:  字符串相加
    /// problems: https://leetcode.cn/problems/add-strings/
    /// date: 20230717
    /// </summary>

    public static class Solution415
    {
        public static string AddStrings(string num1, string num2) {
            int length1 = num1.Length;
            int length2 = num2.Length;
            int total = Math.Max(length1, length2) + 1;
            var result = new int[total];
            
            int i1 = length1 - 1;
            int i2 = length2 - 1;
            int cur = 0;

            total--;

            while(i1 >= 0 || i2 >= 0){
                int sum = cur;
                if(i1 >= 0)
                    sum += (num1[i1--] - '0');
                
                if(i2 >= 0)
                    sum += (num2[i2--] - '0');

                if(sum >= 10){
                    cur = 1;
                    sum -= 10;
                }else{
                    cur = 0;
                }

                result[total--] = sum;
            }

            result[0] = cur;

            return string.Concat(cur == 0 ? result[1..] : result );
        }
    }
}