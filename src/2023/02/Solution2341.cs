using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2341
    /// title: 数组能形成多少数对
    /// problems: https://leetcode.cn/problems/maximum-number-of-pairs-in-array/
    /// date: 20230216
    /// </summary>
    public static class Solution2341
    {
        public static int[] NumberOfPairs(int[] nums) {
            Array.Sort(nums);
            int prev = -1;
            var result = new int[2];
            foreach(var num in nums){
                if(num == prev){
                    result[0]++;
                    prev = -1;
                }else{
                    if(prev != -1)
                        result[1]++;

                    prev = num;
                }
            }

            if(prev != -1)
                result[1]++;

            return result;
        }
    }
}