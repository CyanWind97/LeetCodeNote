using System;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 415
    /// title:  字符串相加
    /// problems: https://leetcode.cn/problems/add-strings/
    /// date: 20220512
    /// priority: 0040
    /// time: 00:12:47.96
    public static class CodeTop415
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

            return string.Join("", cur == 0 ? result.Skip(1) : result );
        }
    }
}