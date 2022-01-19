using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 219
    /// title: 存在重复元素 II
    /// problems: https://leetcode-cn.com/problems/contains-duplicate-ii/
    /// date: 20220119
    /// </summary>

    public static class Solution219
    {
        public static bool ContainsNearbyDuplicate(int[] nums, int k) {
            if(k == 0)
                return false;

            int length = nums.Length;
            var hasSet = new HashSet<int>();
            
            for(int i = 0; i < length; i++){
                if(i > k)
                    hasSet.Remove(nums[i - k - 1]);

                if(!hasSet.Add(nums[i]))
                    return true;
            }


            return false;
        }
    }
}