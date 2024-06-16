using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 522
    /// title: 最长特殊序列 II
    /// problems: https://leetcode.cn/problems/longest-uncommon-subsequence-ii/
    /// date: 20220627
    /// </summary>
    public static partial class Solution522
    {
        public static int FindLUSlength(string[] strs) {
            bool IsSubseq(string s, string t){
                int ptS = 0, ptT = 0;
                while(ptS < s.Length && ptT < t.Length){
                    if(s[ptS] == t[ptT])
                        ++ptS;
                    
                    ++ptT;
                }

                return ptS == s.Length;
            }
            
            int length = strs.Length;

            return Enumerable.Range(0, length)
                    .Max(i => Enumerable.Range(0, length)
                                .Any(j => i != j && IsSubseq(strs[i], strs[j]))
                              ? -1
                              : strs[i].Length);
        }
    }
}