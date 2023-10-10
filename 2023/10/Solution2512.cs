using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2512
    /// title: 奖励最顶尖的 K 名学生
    /// problems: https://leetcode.cn/problems/reward-top-k-students/?envType=daily-question&envId=2023-10-11
    /// date: 20231011
    /// </summary>
    public static class Solution2512
    {
        public static IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k) {
            var words = new Dictionary<string, int>();
            
            foreach(var feedback in positive_feedback){
                words[feedback] = 3;
            }

            foreach(var feedback in negative_feedback){
                words[feedback] = -1;
            }


            int length = report.Length;
            var scores = new int[length];
            for(int i = 0; i < length; i++){
                scores[i] = report[i].Split(" ")
                                .Sum(word => words.GetValueOrDefault(word, 0));
            }

            return Enumerable.Range(0, length)
                    .OrderByDescending(i => scores[i])
                    .ThenBy(i => student_id[i])
                    .Take(k)
                    .Select(i => student_id[i])
                    .ToArray();
        }
    }
}