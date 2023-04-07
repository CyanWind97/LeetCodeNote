using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1125
    /// title: 最小的必要团队
    /// problems: https://leetcode.cn/problems/smallest-sufficient-team/
    /// date: 20230408
    /// </summary>
    public static class Solution1125
    {
        public static int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people) {
            int length = req_skills.Length;
            int n = people.Count;
            var skillIndex = new Dictionary<string, int>();

            for(int  i = 0; i < length; i++){
                skillIndex.Add(req_skills[i], i);
            }

            var dp = new int[1 << length];
            Array.Fill(dp, n);

            dp[0] = 0;
            var prevSkill = new int[1 << length];
            var prevPeople = new int[1 << length];
            for (int i = 0; i < n; ++i) {
                int curSkill = 0;
                foreach (var s in people[i]) {
                    curSkill |= 1 << skillIndex[s];
                }

                for (int prev = 0; prev < dp.Length; prev++) {
                    int comb = prev | curSkill;
                    if (dp[comb] > dp[prev] + 1) {
                        dp[comb] = dp[prev] + 1;
                        prevSkill[comb] = prev;
                        prevPeople[comb] = i;
                    }
                }
            }

            var result = new List<int>();
            int skills = (1 << length) - 1;
            while (skills > 0) {
                result.Add(prevPeople[skills]);
                skills = prevSkill[skills];
            }
            
            return result.ToArray();
        }
    }
}