using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1832
    /// title:  判断句子是否为全字母句
    /// problems: https://leetcode.cn/problems/check-if-the-sentence-is-pangram/
    /// date: 20221213
    /// </summary>
    public static class Solution1832
    {
        public static bool CheckIfPangram(string sentence) {
            return sentence.Distinct().Count() == 26;
        }
    }
}