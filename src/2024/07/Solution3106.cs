using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3106
/// title: 满足距离约束且字典序最小的字符串
/// problems: https://leetcode.cn/problems/lexicographically-smallest-string-after-operations-with-constraint
/// date: 20240727
/// </summary>
public static class Solution3106
{
    public static string GetSmallestString(string s, int k) {
        var span = new Span<char>([.. s]);

        for(int i = 0; i < span.Length && k > 0; i++){
            if (span[i] is 'a')
                continue;

            int diff = span[i] - 'a';
            if (26 - diff < diff && k >= 26 - diff){
                span[i] = 'a';
                k -= 26 - diff;
            }else{
                var add = Math.Min(k, diff);
                span[i] = (char)(span[i] - add);
                k -= add;
            }
        }

        return new string(span);
    }
}
