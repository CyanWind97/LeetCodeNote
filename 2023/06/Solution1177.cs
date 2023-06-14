using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1177
    /// title: 构建回文串检测
    /// problems: https://leetcode.cn/problems/can-make-palindrome-from-substring/
    /// date: 20230615
    /// </summary>
    public static class Solution1177
    {
        public static IList<bool> CanMakePaliQueries(string s, int[][] queries) {
            int length = s.Length;
            int[,] dp = new int[length + 1, 26];
            for(int i = 0; i < length; i++){
                for(int j = 0; j < 26; j++){
                    dp[i + 1, j] = dp[i, j];
                }
                dp[i + 1, s[i] - 'a']++;
            }

            int GetCount(int left, int right){
                int count = 0;
                for(int i = 0; i < 26; i++){
                    count += (dp[right + 1, i] - dp[left, i]) % 2;
                }

                return count / 2;
            }

            int queriesLength = queries.Length;
            bool[] result = new bool[queriesLength];
            for(int i = 0; i < queriesLength; i++){
                int[] query = queries[i];
                result[i] = GetCount(query[0], query[1]) <= query[2];
            }

            return result;
        }
    }
}