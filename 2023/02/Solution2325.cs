using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2325
    /// title: 解密消息 X 矩阵
    /// problems: https://leetcode.cn/problems/decode-the-message/
    /// date: 20230201
    /// </summary>
    public static class Solution2325
    {
        public static string DecodeMessage(string key, string message) {
            var map = key.ToHashSet()
                        .Where(c => char.IsLower(c))
                        .Select((c, i) => ((char)(i + 'a'), c))
                        .ToDictionary(p => p.c, p => p.Item1);
            map.Add(' ', ' ');

            var chars = message.Select(c => map[c]).ToArray();

            return new string(chars);
        }
    }
}