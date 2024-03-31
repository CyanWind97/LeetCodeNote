using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2578
    /// title: 最小和分割
    /// problems: https://leetcode.cn/problems/split-with-minimum-sum/?envType=daily-question&envId=2023-10-09
    /// date: 20231009
    /// </summary>
    public static class Solution2578
    {
        public static int SplitNum(int num) {
            var stnum = num.ToString().ToCharArray();
            Array.Sort(stnum);
            int num1 = 0, num2 = 0;
            for (int i = 0; i < stnum.Length; ++i) {
                if (i % 2 == 0) 
                    num1 = num1 * 10 + (stnum[i] - '0');
                else 
                    num2 = num2 * 10 + (stnum[i] - '0');
            }
            
            return num1 + num2;

        }
    }
}