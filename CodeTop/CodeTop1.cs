using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 1
    /// title:  两数之和
    /// problems: https://leetcode.cn/problems/two-sum/
    /// date: 20220509
    /// priority: 0022
    /// time: 00:03:50.54

    public static class CodeTop1
    {
        public static int[] TwoSum(int[] nums, int target) {
            int length = nums.Length;
            var lookup = new Dictionary<int, int>();
            
            for(int i = 0; i < length; i++){
                if(lookup.ContainsKey(target - nums[i]))
                    return new int[2]{lookup[target - nums[i]], i};
                
                lookup[nums[i]] = i;
            }

            return new int[] { -1, -1};
        }
    }
}