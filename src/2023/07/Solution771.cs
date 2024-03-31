using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 771
    /// title: 宝石与石头
    /// problems: https://leetcode.cn/problems/jewels-and-stones/
    /// date: 20230724
    /// </summary>
    public static class Solution771
    {
        public static int NumJewelsInStones(string jewels, string stones) {
            return stones.Count(c => jewels.Contains(c));
        }
    }
}