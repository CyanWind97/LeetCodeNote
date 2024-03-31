using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2525
    /// title: 根据规则将箱子分类
    /// problems: https://leetcode.cn/problems/categorize-box-according-to-criteria/?envType=daily-question&envId=2023-10-20
    /// date: 20231020
    /// </summary>
    public static class Solution2525
    {
        public static string CategorizeBox(int length, int width, int height, int mass) {
            int limit = 10_000;
            var isBulky = length >= limit || width >= limit || height >= limit
                        || (long)length * width * height >= 1_000_000_000;
            
            var isHeavy = mass >= 100;

            return isBulky switch
            {
                true when isHeavy => "Both",
                true => "Bulky",
                _ when isHeavy => "Heavy",
                _ => "Neither"
            };
        } 
    }
}