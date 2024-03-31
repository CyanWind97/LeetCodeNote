using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2707
    /// title: 字符串中的额外字符
    /// problems: https://leetcode.cn/problems/extra-characters-in-a-string/description/?envType=daily-question&envId=2024-01-09
    /// date: 20240109
    /// </summary>

    public static class Solution2707
    {
        // 参考解答
        // dp
        public static int MinExtraChar(string s, string[] dictionary) {
            int length = s.Length;
            var dp = Enumerable.Repeat(int.MaxValue, length + 1).ToArray();
            var map = new Dictionary<string, int>();
            foreach(var word in dictionary){
                map.TryAdd(word, 0);
                map[word]++;
            }
            

            dp[0] = 0;
            for(int i = 1; i <= length; i++){
                dp[i] = dp[i - 1] + 1;
                for(int j = 0; j < i; j++){
                    if(map.ContainsKey(s.Substring(j, i - j))){
                        dp[i] = Math.Min(dp[i], dp[j]);
                    }
                }
            }

            return dp[length];
        }
    }
}