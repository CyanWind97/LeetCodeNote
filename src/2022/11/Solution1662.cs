using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1662
    /// title: 检查两个字符串数组是否相等
    /// problems: https://leetcode.cn/problems/check-if-two-string-arrays-are-equivalent/
    /// date: 20221101
    /// </summary>
    public static class Solution1662
    {
        public static bool ArrayStringsAreEqual(string[] word1, string[] word2) {
            var chars1 =  word1.SelectMany(word => word.Select(c => c));
            var chars2 = word2.SelectMany(word => word.Select(c => c));
            
            return chars1.SequenceEqual(chars2);
        }
    }
}