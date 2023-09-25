using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2582
    /// title: 递枕头
    /// problems: https://leetcode.cn/problems/pass-the-pillow/?envType=daily-question&envId=2023-09-26
    /// date: 20230926
    /// </summary>
    public static class Solution2582
    {
        public static int PassThePillow(int n, int time) {
            int k = time % (2* n - 2) + 1;
            return k > n ? 2 * n - k : k;
        }
    }
}