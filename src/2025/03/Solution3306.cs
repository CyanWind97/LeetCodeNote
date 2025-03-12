using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3305
/// title: 元音辅音字符串计数 II
/// problems: https://leetcode.cn/problems/count-of-substrings-containing-every-vowel-and-k-consonants-ii
/// date: 20250313
/// </summary>
public static class Solution3306
{
    public static long CountOfSubstrings(string word, int k) {
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        long Count(int m) {
            int n = word.Length, consonants = 0;
            long res = 0;
            Dictionary<char, int> occur = new Dictionary<char, int>();
            for (int i = 0, j = 0; i < n; i++) {
                while (j < n && (consonants < m || occur.Count < 5)) {
                    char ch = word[j];
                    if (vowels.Contains(ch)) {
                        if (!occur.ContainsKey(ch)) occur[ch] = 0;
                        occur[ch]++;
                    } else {
                        consonants++;
                    }
                    j++;
                }
                if (consonants >= m && occur.Count == 5) {
                    res += n - j + 1;
                }
                char left = word[i];
                if (vowels.Contains(left)) {
                    occur[left]--;
                    if (occur[left] == 0) {
                        occur.Remove(left);
                    }
                } else {
                    consonants--;
                }
            }
            return res;
        }

        return Count(k) - Count(k + 1);
    }
}
