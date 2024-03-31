using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1419
    /// title:  数青蛙
    /// problems: https://leetcode.cn/problems/minimum-number-of-frogs-croaking/
    /// date: 20230506
    /// </summary>
    public static class Solution1419
    {
        public static int MinNumberOfFrogs(string croakOfFrogs) {
            int length = croakOfFrogs.Length;
            if (length % 5 != 0) 
                return -1;

            int result = 0;
            int frogNum = 0;
            var count = new int[4];
            var map = new Dictionary<char, int>() {
                {'c', 0}, {'r', 1}, {'o', 2}, {'a', 3}, {'k', 4}
            };

            foreach (char c in croakOfFrogs) {
                int t = map[c];
                if (t == 0) {
                    count[t]++;
                    frogNum++;
                    if (frogNum > result) 
                        result = frogNum;
                }else{
                    if (count[t - 1] == 0) 
                        return -1;
                    
                    count[t - 1]--;
                    if (t == 4) 
                        frogNum--;
                    else
                        count[t]++;
                }
            }

            if (frogNum > 0)
                return -1;

            return result;
        }
    }
}