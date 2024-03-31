using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2451
    /// title: 差值数组不同的字符串
    /// problems: https://leetcode.cn/problems/odd-string-difference/
    /// date: 20230525
    /// </summary>
    public static class Solution2451
    {
        public static string OddString(string[] words) {
            int length = words.Length;
            int n = words[0].Length;
            
            bool isOdd(string word1, string word2){
                int diff = word2[0] - word1[0];
                for(int i = 1; i < n; i++){
                    if(word2[i] - word1[i] != diff)
                        return true;    
                }

                return false;
            }

            if(isOdd(words[0], words[1]))
                return isOdd(words[0], words[2])
                    ? words[0]
                    : words[1];
            
            for(int i = 2; i < length; i++){
                if(isOdd(words[0], words[i]))
                    return words[i];
            }

            return words[0];
        }
    }
}