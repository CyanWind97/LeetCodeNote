using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3305
/// title: 元音辅音字符串计数 I
/// problems: https://leetcode.cn/problems/count-of-substrings-containing-every-vowel-and-k-consonants-i
/// date: 20250312
/// </summary>
public static class Solution3305
{
    public static int CountOfSubstrings(string word, int k) {
        int count = 0;
        int n = word.Length;
        static bool IsVowel(char c) {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
        
        // 滑动窗口
        for (int i = 0; i < n; i++) {
            // 使用集合记录遇到的元音字母
            HashSet<char> vowels = new HashSet<char>();
            int consonantCount = 0; // 辅音字母计数
            
            for (int j = i; j < n; j++) {
                char c = word[j];
                
                // 判断当前字符是元音还是辅音
                if (IsVowel(c)) {
                    vowels.Add(c);
                } else {
                    consonantCount++;
                }
                
                // 检查条件：包含所有元音且恰好有k个辅音
                if (vowels.Count == 5 && consonantCount == k) {
                    count++;
                }
                
                // 如果辅音超过k个，可以提前结束当前窗口
                if (consonantCount > k) {
                    break;
                }
            }
        }
    
        return count;
    }
}
