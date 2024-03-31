using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1048
    /// title: 最长字符串链
    /// problems: https://leetcode.cn/problems/longest-string-chain/
    /// date: 20230427
    /// </summary>
    public static class Solution1048
    {
        public static int LongestStrChain(string[] words) {
            int length = words.Length;
            Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));

            var dp = new int[length];

            bool IsPredecessor(string word1, string word2)
            {
                int l1 = word1.Length;
                int l2 = word2.Length;
                
                int i = 0, j = 0;
                while(i < l1 && j < l2){
                    if(word1[i] == word2[j])
                        i++;
                    
                    j++;
                }

                return i == l1;
            }

            int result = 0;
            for(int i = 0; i < length; i++){
                int max = 0;
                for(int j = i - 1; j >= 0; j--){
                    if(words[i].Length - words[j].Length > 1)
                        break;
                    
                    if(words[i].Length == words[j].Length)
                        continue;
                    
                    if(IsPredecessor(words[j], words[i]))
                        max = Math.Max(max, dp[j]);
                }

                dp[i] = max + 1;
                result = Math.Max(result, dp[i]);
            }

            return result;
        }
    }
}