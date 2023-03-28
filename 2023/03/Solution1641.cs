using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1641
    /// title: 统计字典序元音字符串的数目
    /// problems: https://leetcode.cn/problems/count-sorted-vowel-strings/
    /// date: 20230329
    /// </summary>
    public static class Solution1641
    {
        public static int CountVowelStrings(int n) {
            var dp = new int[n, 5];

            for(int i = 0; i < 5; i++){
                dp[0, i] = 1;
            }

            for(int i = 1; i < n; i++){
                for(int j = 0; j < 5; j++){
                    dp[i, j] = Enumerable.Range(j, 5 - j)
                                            .Sum(k => dp[i - 1, k]);
                }
            }

            int result = 0;
            for(int i = 0; i < 5; i++){
                result += dp[n - 1, i];
            }

            return result;
        }

        // 数学
        public static int CountVowelStrings_1(int n) {
            return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
        }
    }
}