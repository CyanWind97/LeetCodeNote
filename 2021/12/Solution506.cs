using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 506
    /// title:  相对名次
    /// problems: https://leetcode-cn.com/problems/relative-ranks/
    /// date: 20211202
    /// </summary>
    public static class Solution506
    {
        public static string[] FindRelativeRanks(int[] score) {
            int length = score.Length;
            var result = new string[length];

            var sortedInfo = score.Select((Score, Index) => (Score, Index))
                                  .OrderByDescending(x => x.Score)
                                  .ToArray();

            
            result[sortedInfo[0].Index] = "Gold Medal";
            if (length > 1)
                result[sortedInfo[1].Index] = "Silver Medal";

            if (length > 2)
                result[sortedInfo[2].Index] = "Bronze Medal";

            for(int i = 3; i < length; i++){
                result[sortedInfo[i].Index] = (i + 1).ToString();
            }

            return result;
        }
    }
}