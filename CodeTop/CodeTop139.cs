using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 139
    /// title:  单词拆分
    /// problems: https://leetcode.cn/problems/word-break/
    /// date: 20220519
    /// priority: 0090
    /// time: 00:25:44.87
    /// </summary>
    public static class CodeTop139
    {
        public static bool WordBreak(string s, IList<string> wordDict) {
            var wordSet = wordDict.ToHashSet();

            int length = s.Length;
            var dp = new bool[length + 1];
            dp[0] = true;
            for(int i = 1; i <= length; i++){
                for(int j = 0; j < i; j++){
                    if(dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            
            return dp[length];
        }
    }
}