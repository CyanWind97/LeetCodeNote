using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2395
    /// title: 和相等的子数组
    /// problems: https://leetcode.cn/problems/find-subarrays-with-equal-sum/
    /// date: 20230326
    /// </summary>
    public static class Solution2395
    {
        public static bool FindSubarrays(int[] nums) {
            int length = nums.Length;
            int sum = nums[0];
            var set = new HashSet<int>();
            for(int i = 1; i < length; i++){
                sum += nums[i];
                if(!set.Add(sum))
                    return true;
                
                sum -= nums[i - 1];
            }
            
            return false;
        }
    }
}