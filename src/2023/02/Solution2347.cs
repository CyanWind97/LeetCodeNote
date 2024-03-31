using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2347
    /// title: 最好的扑克手牌
    /// problems: https://leetcode.cn/problems/best-poker-hand/
    /// date: 20230220
    /// </summary>
    public static class Solution2347
    {
        public static string BestHand(int[] ranks, char[] suits) {
            if(suits.Distinct().Count() == 1)
                return "Flush";
            
            var groups =  ranks.GroupBy(rank => rank).ToArray();
            if(groups.Length == 5)
                return "High Card";
            
            return groups.Any(g => g.Count() > 2)
                ? "Three of a Kind"
                : "Pair";
        }
    }
}