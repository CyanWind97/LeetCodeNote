using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 484
    /// title: 扰乱字符串
    /// problems: https://leetcode-cn.com/problems/scramble-string/
    /// date: 20210416
    /// </summary>
    public static class Solution484
    {
        // 参考解答 dfs 记忆数组
        public static bool IsScramble(string s1, string s2) {
            int length = s1.Length;

            bool CheckSimilary(int i1, int i2, int length)
            {
                Dictionary<char, int> dic = new Dictionary<char, int>();
                for(int i = i1; i < i1 + length; i++){
                    if(!dic.ContainsKey(s1[i]))
                        dic[s1[i]] = 1;
                    else
                        dic[s1[i]]++;
                }
                for(int i = i2; i < i2 + length; i++){
                    if(!dic.ContainsKey(s2[i]))
                        return false;
                    else
                        dic[s2[i]]--;
                }

                return dic.All(x => x.Value == 0);
            }

            int[,,] memo = new int[length, length, length + 1];
            
            bool Dfs(int i1, int i2, int length){
                if(memo[i1,i2,length] != 0)
                    return memo[i1, i2, length] == 1;

                if(s1.AsSpan(i1, length).Equals(s2.AsSpan(i2, length), StringComparison.Ordinal)){
                    memo[i1, i2, length] = 1;
                    return true;
                }

                if(!CheckSimilary(i1, i2, length)){
                    memo[i1, i2, length] = -1;
                    return false;
                }

                for(int i = 1; i < length; i++){
                    if(Dfs(i1, i2, i) && Dfs(i1 + i, i2 + i, length - i)){
                        memo[i1, i2, length] = 1;
                        return true;
                    }

                    if(Dfs(i1, i2 + length - i, i) && Dfs(i1 + i, i2, length - i)){
                        memo[i1, i2, length] = 1;
                        return true;
                    }
                }
                
                memo[i1, i2, length] = -1;
                return false;
            }

            return Dfs(0, 0, length);
        }
    }
}