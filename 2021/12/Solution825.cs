using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 825
    /// title:  适龄的朋友
    /// problems: https://leetcode-cn.com/problems/friends-of-appropriate-ages/
    /// date: 20211227
    /// </summary>
    public static class Solution825
    {
        public static int NumFriendRequests(int[] ages) {
            var dic = ages.GroupBy(x => x)
                          .OrderBy(x => x.Key)
                          .ToDictionary(x => x.Key, x => x.Count());
            
            var keys = dic.Keys.ToList();
            var values = dic.Values.ToList();
            var sums = new int[values.Count + 1];
            
            for(int i = 1; i < values.Count + 1; i++){
                sums[i] = sums[i - 1] + values[i - 1];
            }

            int result = 0;
            
            for(int i = 0; i < keys.Count; i++){
                if(keys[i] <= 14)
                    continue;
                
                var boud = keys[i] / 2  + 7;
                var index = keys.BinarySearch(0, i + 1, boud, null);
                if(index < 0)
                    index = ~index;
                else
                    index = index + 1;

                result += values[i] * (sums[i + 1] - sums[index]) - values[i];
            }


            return result;
        }
    }
}