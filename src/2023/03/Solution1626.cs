using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1626
    /// title:  无矛盾的最佳球队
    /// problems: https://leetcode.cn/problems/best-team-with-no-conflicts/
    /// date: 20230322
    /// </summary>
    public static class Solution1626
    {
        public static int BestTeamScore(int[] scores, int[] ages) {
            int n = scores.Length;
            var people = Enumerable.Range(0, n)
                            .Select(i => (scores[i], ages[i]))
                            .OrderBy(p => p.Item1)
                            .ThenBy(p => p.Item2)
                            .ToArray<(int Score, int Age)>();

            var dp = new int[n];
            int result = 0;
            for(int i = 0; i < n; i++){
                for(int j = i - 1; j >= 0; j--){
                    if(people[j].Age <= people[i].Age)
                        dp[i] = Math.Max(dp[i], dp[j]);
                }

                dp[i] += people[i].Score;
                result = Math.Max(result, dp[i]);
            }

            return result;
        }
    }
}