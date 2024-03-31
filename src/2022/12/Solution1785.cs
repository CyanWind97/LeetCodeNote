using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1785
    /// title:  构成特定和需要添加的最少元素
    /// problems: https://leetcode.cn/problems/minimum-elements-to-add-to-form-a-given-sum/
    /// date: 20221216
    /// </summary>
    public static class Solution1785
    {
        public static int MinElements(int[] nums, int limit, int goal) {
            long sum = 0;
            foreach(var num in nums){
                sum += num;
            }

            return (int)((Math.Abs(sum - goal) + limit - 1) / limit);
        }
    }
}