using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 539
    /// title: 最小时间差
    /// problems: https://leetcode-cn.com/problems/minimum-time-difference/
    /// date: 20220118
    /// </summary>
    public static class Solution539
    {
        public static int FindMinDifference(IList<string> timePoints) {
            if(timePoints.Count > 1440)
                return 0;

            int GetMinutes(string t)
                => ((t[0] - '0') * 10 + t[1] - '0') * 60 + (t[3] - '0') * 10 + t[4] - '0';
            
            var minutes = timePoints.Select(GetMinutes)
                                    .OrderBy(x => x)
                                    .ToList();

            int result = 1441;

            for(int i = 1; i < minutes.Count; i++){
                result = Math.Min(result, minutes[i] - minutes[i - 1]);
            }

            return Math.Min(result, 1440 + minutes[0] - minutes.Last());
        }
    }
}