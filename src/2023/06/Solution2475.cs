using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2475
    /// title: 数组中不等三元组的数目
    /// problems: https://leetcode.cn/problems/number-of-unequal-triplets-in-array/
    /// date: 20230613
    /// </summary>
    public static class Solution2475
    {
        public static int UnequalTriplets(int[] nums) {
            int length = nums.Length;
            int result = 0;
            Array.Sort(nums);
            for(int i = 0; i < length - 2; i++){
                for(int j = i + 1; j < length - 1; j++){
                    for(int k = j + 1; k < length; k++){
                        if(nums[i] != nums[j] && nums[j] != nums[k] && nums[i] != nums[k])
                            result++;
                    }
                }
            }

            return result;
        }
    }
}