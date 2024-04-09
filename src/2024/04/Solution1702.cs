using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1702
/// title: 修改后的最大二进制字符串
/// problems: https://leetcode.cn/problems/maximum-binary-string-after-change
/// date: 20240410
/// </summary>
public static class Solution1702
{
    public static string MaximumBinaryString(string binary) {
        int length = binary.Length;
        var index = binary.IndexOf('0');
        if (index == -1)
            return binary;

        int zeors = 0;
        var span = new Span<char>(binary.ToCharArray());
        for(int i = index; i < length; i++){
            if(span[i] == '0')
                zeors++;
            
            span[i] = '1';
        }

        span[index + zeors - 1] = '0';

        return new string(span);
    }
}
