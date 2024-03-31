using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2136
    /// title: 全部开花的最早一天
    /// problems: https://leetcode.cn/problems/earliest-possible-day-of-full-bloom/?envType=daily-question&envId=2023-09-30
    /// date: 20230930
    /// </summary>
    public static class Solution2136
    {
        public static int EarliestFullBloom(int[] plantTime, int[] growTime) {
            int length = plantTime.Length;
            var infos = Enumerable.Range(0, length)
                            .Select(i => (plantTime[i], growTime[i]))
                            .OrderByDescending(x => x.Item2)
                            .ToArray();
            
            int result = 0;
            int prev = 0;
            foreach(var (plant, grow) in infos){
                result = Math.Max(result, prev + plant + grow);
                prev += plant;
            }

            return result;
        }
    }
}