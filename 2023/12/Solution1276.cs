using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1276
    /// title: 不浪费原料的汉堡制作方案
    /// problems: https://leetcode.cn/problems/number-of-burgers-with-no-waste-of-ingredients/description/?envType=daily-question&envId=2023-12-25
    /// date: 20231225
    /// </summary>
    public static class Solution1276
    {
        public static IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices) {
            if (tomatoSlices % 2 != 0 || tomatoSlices < cheeseSlices * 2 || tomatoSlices > cheeseSlices * 4)
                return Array.Empty<int>();
            
            int jumbo = (tomatoSlices - cheeseSlices * 2) / 2;
            int small = cheeseSlices - jumbo;

            return new int[]{jumbo, small};
        }
    }
}