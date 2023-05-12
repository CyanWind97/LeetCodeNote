using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2441
    /// title: 与对应负数同时存在的最大正整数
    /// problems: https://leetcode.cn/problems/largest-positive-integer-that-exists-with-its-negative/
    /// date: 20230512
    /// </summary>
    public static class Solution2441
    {
        public static int FindMaxK(int[] nums) {
            int max = -1;
            var set = new HashSet<int>();
            foreach(var num in nums){
                if (set.Contains(-num))
                    max = Math.Max(Math.Abs(num), max);
                
                set.Add(num);
            }

            return max;
        }
    }
}