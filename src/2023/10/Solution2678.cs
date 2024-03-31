using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2678
    /// title: 老人的数目
    /// problems: https://leetcode.cn/problems/number-of-senior-citizens/?envType=daily-question&envId=2023-10-23
    /// date: 20231023
    /// </summary>
    public static class Solution2678
    {
        public static int CountSeniors(string[] details) {
            return details.Count(x => x[11..13].CompareTo("60") > 0);
        }
    }
}