using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3298
/// title: 统计重新排列后包含另一个字符串的子字符串数目 II
/// problems: https://leetcode.cn/problems/count-substrings-that-can-be-rearranged-to-contain-a-string-ii
/// date: 20250110
/// </summary>
public static class Solution3298
{
    public static long ValidSubstringCount(string word1, string word2) {
        var key = new int[26];
        foreach(var c in word2){
            key[c - 'a']++;
        }

        long result = 0;
        var count = key.Count(x => x > 0);
        int l = 0;
        int r = 0;
        
        void Update(int c, int add){
            key[c] -= add;
            if (add == 1 && key[c] == 0)
                count--;
            else if (add == -1 && key[c] == 1)
                count++;
        }

        while(l < word1.Length){
            while(r < word1.Length && count > 0){
                Update(word1[r] - 'a', 1);
                r++;
            }

            if (count == 0)
                result += word1.Length - r + 1;
            
            Update(word1[l] - 'a', -1);
            l++;
        }

        return result;
    }
}
