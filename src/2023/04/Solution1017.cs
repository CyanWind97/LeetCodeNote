using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1017
    /// title: 负二进制转换
    /// problems: https://leetcode.cn/problems/convert-to-base-2/
    /// date: 20230406
    /// </summary>
    public static class Solution1017
    {
        public static string BaseNeg2(int n) {
            if(n == 0 || n == 1)
                return n.ToString();

            var sb = new StringBuilder();
            while(n != 0) {
                int remainder = n & 1;
                sb.Append(remainder);
                n -= remainder; 
                n /= -2;
            }
            
            var s = sb.ToString();

            return new string(s.Reverse().ToArray());
        }
    }
}