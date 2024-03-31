using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 833
    /// title: 字符串中的查找与替换
    /// problems: https://leetcode.cn/problems/merge-two-binary-trees/
    /// date: 20230815
    /// </summary>
    public static class Solution833
    {
        public static string FindReplaceString(string s, int[] indices, string[] sources, string[] targets) {
            int length = s.Length;
            var match = Enumerable.Repeat(-1, length).ToArray();
            var span = s.AsSpan();

            for (int i = 0; i < indices.Length; ++i) {
                int index = indices[i];
                if (index + sources[i].Length > length) 
                    continue;

                if (span.Slice(index, sources[i].Length).SequenceEqual(sources[i])) 
                    match[index] = i;
            }

            var sb = new System.Text.StringBuilder();
            int pointer = 0;
            while (pointer < length) {
                if (match[pointer] >= 0) {
                    sb.Append(targets[match[pointer]]);
                    pointer += sources[match[pointer]].Length;
                } else {
                    sb.Append(s[pointer++]);
                }
            }
            
            return sb.ToString();
        }
    }
}