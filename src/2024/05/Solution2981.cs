using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2981
/// title: 找出出现至少三次的最长特殊子字符串 I
/// problems: https://leetcode.cn/problems/find-longest-special-substring-that-occurs-thrice-i
/// date: 20240529
/// </summary>
public static class Solution2981
{
    public static int MaximumLength(string s) {
        int length = s.Length;
        var counts = new (int Max1, int Max2, int Max3)[26];

        int count = 0;
        for(int i = 0; i < length; i++){
            count++;
            if (!(i + 1 == length || s[i] != s[i + 1]))
                continue;
            
            int ch = s[i] - 'a';
            if (count > counts[ch].Max1)
                counts[ch] = (count, counts[ch].Max1, counts[ch].Max2);
            else if(count > counts[ch].Max2)
                counts[ch] = (counts[ch].Max1, count, counts[ch].Max2);
            else if(count > counts[ch].Max3)
                counts[ch] = (counts[ch].Max1, counts[ch].Max2, count);

            count = 0;
        }
        

        int result = -1;
        foreach(var (max1, max2, max3) in counts){
            if (max1 > 2)
                result = Math.Max(result, max1 - 2);

            if (max2 > 0 && max1 > 1)
                result = Math.Max(result, Math.Min(max1  - 1, max2));
            
            if (max3 > 0)
                result = Math.Max(result, max3);
        }

        return result;
    }
}
