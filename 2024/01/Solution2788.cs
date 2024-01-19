using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2788
    /// title: 按分隔符拆分字符串
    /// problems: https://leetcode.cn/problems/split-strings-by-separator/description/?envType=daily-question&envId=2024-01-20
    /// date: 20240120
    /// </summary>
    public static class Solution2788
    {
        public static IList<string> SplitWordsBySeparator(IList<string> words, char separator) {
            return words.SelectMany(x => x.Split(separator))
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToList();
        }       
    }
}