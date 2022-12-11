using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1781
    /// title:  所有子字符串美丽值之和
    /// problems: https://leetcode.cn/problems/sum-of-beauty-of-all-substrings/
    /// date: 20221212
    /// </summary>
    public static class Solution1781
    {
        public static int BeautySum(string s) {
            int ans = 0;
            for (int i = 0;i < s.Length;++i) {
                int[] count = new int[26];
                for (int j = i;j < s.Length;++j) {
                    char ch = s[j];
                    count[ch - 'a'] += 1;
                    int max = int.MinValue;
                    int min = int.MaxValue;
                    foreach (var value in count) {
                        if (value > 0 && value > max) 
                            max = value;
                        
                        if (value > 0 && value < min) 
                            min = value;
                    }
                    ans += (max - min);
                }
            }
            return ans;
        }
    }
}