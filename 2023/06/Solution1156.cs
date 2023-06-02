using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1159
    /// title: 单字符重复子串的最大长度
    /// problems: https://leetcode.cn/problems/swap-for-longest-repeated-character-substring/
    /// date: 20230603
    /// </summary>
    public static class Solution1156
    {
        public static int MaxRepOpt1(string text) {
            int length = text.Length;
            var count =  text.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            int result = 0;
            for(int i = 0; i < length; ) {
                int j = i;
                while(j < length && text[j] == text[i])
                    j++;

                int curCount = j - i;
                if (curCount < count[text[i]] && (j < length || i > 0))
                    result = Math.Max(result, curCount + 1);
                
                int k = j + 1;
                while(k < length && text[k] == text[i])
                    k++;

                result = Math.Max(result, Math.Min(k - i, count[text[i]]));
                i = j;
            }

            return result;
        }
    }
}