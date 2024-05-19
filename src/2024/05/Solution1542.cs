using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

///<summary>
/// no: 1542
/// title: 最长的超赞子字符串
/// problems: https://leetcode.cn/problems/find-longest-awesome-substring
/// date: 20240520
/// </summary
public static class Solution1542
{
    public static int LongestAwesome(string s) {
        int length = s.Length;
        var prefix = new Dictionary<int, int>();
        prefix[0] = -1;
        int result = 0;
        int mask = 0;
        for (int i = 0; i < length; i++){
            int num = s[i] - '0';
            prefix[num] = i;
            mask ^= 1 << num;
            if (prefix.TryGetValue(mask, out int value))
                result = Math.Max(result, i - value);
            else
                prefix[mask] = i;
            
            for (int k = 0; k < 10; k++){
                int temp = mask ^ (1 << k);
                if (prefix.ContainsKey(temp))
                    result = Math.Max(result, i - prefix[temp]);
            }
        }

        return result;   
    }
}
