using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 06
    /// title: 宝石补给
    /// problems: https://leetcode.cn/problems/na-ying-bi/?envType=daily-question&envId=2023-09-20
    /// date: 20230920
    /// type: lcp
    /// </summary>
    public class Solution_lcp_06
    {
        public static int MinCount(int[] coins) {
            return coins.Sum(count => (count + 1) / 2);
        }
    }
}