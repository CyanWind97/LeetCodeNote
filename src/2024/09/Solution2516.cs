using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2516
/// title: 每种字符至少取 K 个
/// problems: https://leetcode.cn/problems/take-k-of-each-character-from-left-and-right
/// date: 20240927
/// </summary>
public static class Solution2516
{
    public static int TakeCharacters(string s, int k) {
        int length = s.Length;
        var count = new int[3];
        foreach(var c in s){
            count[c - 'a']++;
        }

        if (!count.All(x => x >= k))
            return -1;

        int result = length;
        int l = 0;
        for (int r = 0; r < length; r++){
            count[s[r] - 'a']--;
            while(l < r && count.Any(x => x < k)){
                count[s[l] - 'a']++;
                l++;
            }

            if (count.All(x => x >= k))
                result = Math.Min(result, length - (r - l + 1));
        }

        return result;
    }
}
