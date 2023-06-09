using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1170
    /// title: 比较字符串最小字母出现频次
    /// problems: https://leetcode.cn/problems/compare-strings-by-frequency-of-the-smallest-character/
    /// date: 20230610
    /// </summary>
    public static class Solution1170
    {
        public static int[] NumSmallerByFrequency(string[] queries, string[] words) {
            int F(string word){
                var curr = 'z';
                int count = 0;
                foreach(var c in word){
                    if (c < curr){
                        curr = c;
                        count = 1;
                    } else if(c == curr){
                        count++;
                    }
                }

                return count;
            }
            
            var count = new int[12];
            foreach(var f in words.Select(F))
            {
                count[f]++;
            }

            for(int i = 9; i >= 0; i--){
                count[i] += count[i + 1];
            }

            return queries.Select(s => count[F(s) + 1])
                        .ToArray();
        }
    }
}