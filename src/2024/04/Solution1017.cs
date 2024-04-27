using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

 ///<summary>
/// no: 1017
/// title: 负二进制转换
/// problems: https://leetcode.cn/problems/convert-to-base-2/
/// date: 20240428
/// </summary>
public static partial class Solution1017
{
    public static string BaseNeg2(int n) {
        if(n == 0 || n == 1)
            return n.ToString();

        var span = new Span<char>(new char[32]);
        int count  = 0;
        while(n != 0) {
            int remainder = n & 1;
            count++;
            span[^count] = (char)(remainder + '0');
            n -= remainder; 
            n /= -2;
        }

        return new string(span.Slice(32 - count, count));
    }
}
